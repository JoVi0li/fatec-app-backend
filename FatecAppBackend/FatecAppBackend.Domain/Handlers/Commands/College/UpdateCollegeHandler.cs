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

namespace FatecAppBackend.Domain.Handlers.Commands.College
{
    public class UpdateCollegeHandler : Notifiable<Notification>, IHandlerCommand<UpdateCollegeCommand>
    {
        private readonly ICollegeRepository _collegeRepository;

        public UpdateCollegeHandler(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public ICommandResult Execute(UpdateCollegeCommand command)
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

            college.Update(command);

            if (!college.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update, invalid props", college.Notifications);
            }

            _collegeRepository.Update(college);

            return new GenericCommandsResult(true, "College updated", college.Id);
        }
    }
}
