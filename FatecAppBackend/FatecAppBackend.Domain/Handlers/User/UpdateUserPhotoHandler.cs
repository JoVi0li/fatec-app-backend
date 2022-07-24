using FatecAppBackend.Domain.Commands.User;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.User
{
    public class UpdateUserPhotoHandler : Notifiable<Notification>, IHandler<UpdateUserPhotoCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserPhotoHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Execute(UpdateUserPhotoCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var user = _userRepository.GetById(command.Id);

            if(user == null)
            {
                return new GenericCommandsResult(false, "User not found", "Inform another Id");
            }

            user.UpdatePhoto(command.Photo);

            if(!user.IsValid){
                return new GenericCommandsResult(false, "Invalid props", user.Notifications);
            }

            _userRepository.UpdatePhoto(user);

            return new GenericCommandsResult(true, "Photo updated", user.Photo);
        }
    }
}
