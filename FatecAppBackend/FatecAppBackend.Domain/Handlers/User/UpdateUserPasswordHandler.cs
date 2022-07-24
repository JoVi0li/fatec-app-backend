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
    public class UpdateUserPasswordHandler : Notifiable<Notification>, IHandler<UpdateUserPasswordCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserPasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Execute(UpdateUserPasswordCommand command)
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

            user.UpdatePassword(command.Password);

            if (!user.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", user.Notifications);
            }

            _userRepository.UpdatePassword(user);

            return new GenericCommandsResult(true, "Password updated", "Success");
        }
    }
}
