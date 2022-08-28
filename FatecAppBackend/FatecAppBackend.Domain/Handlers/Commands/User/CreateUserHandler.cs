using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Domain.Services;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using FatecAppBackend.Shared.Utils;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Commands.User
{
    public class CreateUserHandler : Notifiable<Notification>, IHandlerCommand<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileService _fileService;

        public CreateUserHandler(IUserRepository userRepository, IFileService fileService)
        {
            _userRepository = userRepository;
            _fileService = fileService;
        }

        public ICommandResult Execute(CreateUserCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var userAlreadyExists = _userRepository.GetByEmail(command.Email);

            if(userAlreadyExists != null)
            {
                return new GenericCommandsResult(false, "User already Exists", command.Notifications);
            }

            command.Password = PasswordEncryption.Encrypt(command.Password);

            command.Photo = _fileService.UploadFile(command.Photo, "fatec-app-images", "");

            Entities.User newUser = new(
                command.Name,
                command.Email,
                command.Password,
                command.Photo,
                command.PhoneNumber,
                command.IdentityDocumentNumber,
                command.IdentityDocumentPhoto,
                command.Gender,
                false
            );

            if (!newUser.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", newUser.Notifications);
            }

            _userRepository.Create(newUser);

            return new GenericCommandsResult(true, "User created", "Token");
        }
    }
}
