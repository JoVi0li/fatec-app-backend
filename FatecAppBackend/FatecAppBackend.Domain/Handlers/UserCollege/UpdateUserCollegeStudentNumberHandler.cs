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
    public class UpdateUserCollegeStudentNumberHandler : Notifiable<Notification>, IHandlerCommand<UpdateUserCollegeStudentNumberCommand>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public UpdateUserCollegeStudentNumberHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(UpdateUserCollegeStudentNumberCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var userCollege = _userCollegeRepository.GetById(command.Id);

            if (userCollege == null)
            {
                return new GenericCommandsResult(false, "UserCollege not found", "Inform another Id");
            }

            userCollege.UpdateStudentNumber(command.StudentNumber);

            if (!userCollege.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update StudentNumber", userCollege.Notifications);
            }

            _userCollegeRepository.UpdateStudentNumber(userCollege);

            return new GenericCommandsResult(true, "StudentNumber updated", userCollege.StudentNumber);
        }
    }
}
