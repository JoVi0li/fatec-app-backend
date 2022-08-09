using FatecAppBackend.Domain.Commands.College;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.College
{
    public class UpdateCollegeCourseHandler : Notifiable<Notification>, IHandlerCommand<UpdateCollegeCourseCommand>
    {
        private readonly ICollegeRepository _collegeRepository;

        public UpdateCollegeCourseHandler(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository; 
        }

        public ICommandResult Execute(UpdateCollegeCourseCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var college = _collegeRepository.GetById(command.Id);

            if(college == null)
            {
                return new GenericCommandsResult(false, "College not found", "Inform another Id");
            }

            college.UpdateCourse(command.Course);

            if (!college.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update Course", college.Notifications);
            }

            _collegeRepository.UpdateCourse(college);

            return new GenericCommandsResult(true, "Course updated", college.Course);
        }
    }
}
