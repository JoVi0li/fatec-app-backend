using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Domain.Services;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.DTOs.User;
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

            var emailAlreadyExists = _userRepository.GetByEmail(command.Email);

            if(emailAlreadyExists != null)
            {
                return new GenericCommandsResult(false, "User already exists", command.Notifications);
            }

            var identityDocNumberAlreadyExists = _userRepository.GetByIdentityDocumentNumber(command.IdentityDocumentNumber);

            if(identityDocNumberAlreadyExists != null)
            {
                return new GenericCommandsResult(false, "User already exists", command.Notifications);
            }

            command.Password = PasswordEncryption.Encrypt(command.Password);

            try
            {
                var userPhotoName = "user-profile-photo-" + command.IdentityDocumentNumber + "-" + Guid.NewGuid();
                command.Photo = _fileService.UploadFile(command.Photo, userPhotoName);
            }
            catch (Exception e)
            {
                return new GenericCommandsResult(false, "Could not upload the user photo", e);
            }

            try
            {
                var userIdentityDocPhotoName = "user-identity-doc-photo-front" + command.IdentityDocumentNumber + "-" + Guid.NewGuid();
                command.IdentityDocumentPhotoFront = _fileService.UploadFile(command.IdentityDocumentPhotoFront, userIdentityDocPhotoName);
            }
            catch (Exception e)
            {
                return new GenericCommandsResult(false, "Could not upload the user identity document photo front", e);
            }

            try
            {
                var userIdentityDocPhotoName = "user-identity-doc-photo-back" + command.IdentityDocumentNumber + "-" + Guid.NewGuid();
                command.IdentityDocumentPhotoBack = _fileService.UploadFile(command.IdentityDocumentPhotoBack, userIdentityDocPhotoName);
            }
            catch (Exception e)
            {
                return new GenericCommandsResult(false, "Could not upload the user identity document photo back", e);
            }

            Entities.User newUser = new(
                command.Name,
                command.Email,
                command.Password,
                command.Photo,
                command.PhoneNumber,
                command.IdentityDocumentNumber,
                command.IdentityDocumentPhotoFront,
                command.IdentityDocumentPhotoBack,
                command.Gender,
                false
            );

            if (!newUser.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", newUser.Notifications);
            }

            _userRepository.Create(newUser);

            return new GenericCommandsResult(true, "User created", newUser.Id);
        }
    }
}
