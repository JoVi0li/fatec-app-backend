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
    public class UpdateUserCollegeGraduationDateHandler : Notifiable<Notification>, IHandler<UpdateUserCollegeGraduationDateCommand>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public UpdateUserCollegeGraduationDateHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(UpdateUserCollegeGraduationDateCommand command)
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

            userCollege.UpdateGraduationDate(command.GraduationDate);

            if (!userCollege.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update GraduationDate", userCollege.Notifications);
            }

            _userCollegeRepository.UpdateGraduationDate(userCollege);

            return new GenericCommandsResult(true, "GraduationDate updated", userCollege.GraduationDate);
        }
    }
}
