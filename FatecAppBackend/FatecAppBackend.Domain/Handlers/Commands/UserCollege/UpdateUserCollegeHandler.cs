using FatecAppBackend.Domain.Commands.UserCollege;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Commands.UserCollege
{
    public class UpdateUserCollegeHandler : Notifiable<Notification>, IHandlerCommand<UpdateUserCollegeCommand>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public UpdateUserCollegeHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(UpdateUserCollegeCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var userCollege = _userCollegeRepository.GetById(command.UserCollege.Id);

            if (userCollege == null)
            {
                return new GenericCommandsResult(false, "UserCollege not found", "Inform another Id");
            }

            userCollege.Update(command.UserCollege);

            if (!userCollege.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update, invalid props", userCollege.Notifications);
            }

            _userCollegeRepository.Update(userCollege);

            return new GenericCommandsResult(true, "UserCollege updated", userCollege.Id);
        }
    }
}
