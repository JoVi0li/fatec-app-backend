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
    public class RemoveUserHandler : Notifiable<Notification>, IHandlerCommand<RemoveUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Execute(RemoveUserCommand command)
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

            if (!user.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid User", user.Notifications);
            }

            _userRepository.Delete(user.Id);

            return new GenericCommandsResult(true, "User removed", user.Id);
        }
    }
}
