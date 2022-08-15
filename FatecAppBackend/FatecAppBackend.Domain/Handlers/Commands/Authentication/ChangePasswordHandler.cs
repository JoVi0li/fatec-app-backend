using FatecAppBackend.Domain.Commands.Authentication;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Commands.Authentication
{
    public class ChangePasswordHandler : Notifiable<Notification>, IHandlerCommand<ChangePasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;

        public ChangePasswordHandler(IUserRepository userRepository, IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _authRepository = authRepository;
        }

        public ICommandResult Execute(ChangePasswordCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", 0);
            }

            var user = _userRepository.GetById(command.User.Id);

            if (user == null)
            {
                return new GenericCommandsResult(false, "Invalid props", 0);
            }

            user.UpdatePassword(command.User.Password);

            if (!user.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid user", 0);
            }

            _authRepository.ChangePassword(user);

            return new GenericCommandsResult(true, "Password changed", user);
        }
    }
}
