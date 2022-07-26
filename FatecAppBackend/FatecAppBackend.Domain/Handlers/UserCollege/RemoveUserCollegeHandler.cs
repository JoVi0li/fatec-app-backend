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

namespace FatecAppBackend.Domain.Handlers.UserCollege
{
    public class RemoveUserCollegeHandler : Notifiable<Notification>, IHandler<RemoveUserCollegeCommand>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public RemoveUserCollegeHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(RemoveUserCollegeCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var userCollege = _userCollegeRepository.GetById(command.Id);

            if(userCollege == null)
            {
                return new GenericCommandsResult(false, "UserCollege not found", "Inform another Id");
            }

            _userCollegeRepository.Delete(userCollege.Id);

            return new GenericCommandsResult(true, "UserCollege removed", userCollege.Id);
        }
    }
}
