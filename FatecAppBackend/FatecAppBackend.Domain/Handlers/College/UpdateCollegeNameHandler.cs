﻿using FatecAppBackend.Domain.Commands.College;
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
    public class UpdateCollegeNameHandler : Notifiable<Notification>, IHandlerCommand<UpdateCollegeNameCommand>
    {
        private readonly ICollegeRepository _collegeRepository;

        public UpdateCollegeNameHandler(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public ICommandResult Execute(UpdateCollegeNameCommand command)
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

            college.UpdateName(command.Name);

            if (!college.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update Name", college.Notifications);
            }

            _collegeRepository.UpdateName(college);

            return new GenericCommandsResult(true, "Name updated", college.Name);
        }
    }
}
