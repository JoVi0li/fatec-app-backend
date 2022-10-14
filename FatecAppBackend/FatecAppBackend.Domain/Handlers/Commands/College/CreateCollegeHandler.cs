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
    public class CreateCollegeHandler : Notifiable<Notification>, IHandlerCommand<CreateCollegeCommand>
    {
        private readonly ICollegeRepository _collegeRepository;

        public CreateCollegeHandler(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public ICommandResult Execute(CreateCollegeCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var collegeAlreadyExists = _collegeRepository.GetByName(command.Name);

            foreach (var item in collegeAlreadyExists)
            {
                if (item?.Name == command.Name && item.Course == command.Course && item.Time == command.Time && item.Localization == command.Localization)
                {
                    return new GenericCommandsResult(false, "College already exists", command.Notifications);
                }
            }

            Entities.College college = new(
                command.Name,
                command.Course,
                command.Time,
                command.Localization
            );

            if (!college.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", college.Notifications);
            }

            _collegeRepository.Create(college);

            return new GenericCommandsResult(true, "College created", college.Id);

        }
    }
}
