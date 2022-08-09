﻿using FatecAppBackend.Domain.Commands.Authentication;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using FatecAppBackend.Shared.Utils;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Authentication
{
    public class SignInHandler : Notifiable<Notification>, IHandler<SignInCommand>
    {
        private readonly IUserRepository _userRepository;

        public SignInHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Execute(SignInCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", 0);
            }

            var user = _userRepository.GetByEmail(command.Email);

            if(user == null)
            {
                return new GenericCommandsResult(false, "Invalid props", 0);
            }

            if(!PasswordEncryption.IsValid(command.Password, user.Password))
            {
                return new GenericCommandsResult(false, "Invalid props", 0);
            }

            return new GenericCommandsResult(true, "Authenticated", user);

        }
    }
}
