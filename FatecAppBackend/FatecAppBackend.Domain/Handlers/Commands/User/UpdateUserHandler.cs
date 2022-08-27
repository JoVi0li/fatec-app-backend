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

namespace FatecAppBackend.Domain.Handlers.Commands.User
{
    public class UpdateUserHandler : Notifiable<Notification>, IHandlerCommand<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Execute(UpdateUserCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var user = _userRepository.GetById(command.UpdateUser.Id);

            if (user == null)
            {
                return new GenericCommandsResult(false, "User not found", "Inform another Id");
            }

            user.Update(command.UpdateUser);

            if (!user.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update, invalid propsa", user.Notifications);
            }

            _userRepository.Update(user);

            return new GenericCommandsResult(true, "User updated", user.Id);
        }
    }
}
