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
    public class GetUserCollegeByIdHandler : Notifiable<Notification>, IHandler<GetUserCollegeByIdCommand>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public GetUserCollegeByIdHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(GetUserCollegeByIdCommand command)
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

            if (!userCollege.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", userCollege.Notifications);
            }

            return new GenericCommandsResult(true, "UserCollege found", userCollege);
        }
    }
}
