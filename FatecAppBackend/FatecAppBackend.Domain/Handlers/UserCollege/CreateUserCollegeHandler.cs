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
    public class CreateUserCollegeHandler : Notifiable<Notification>, IHandler<CreateUserCollegeCommand>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public CreateUserCollegeHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(CreateUserCollegeCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            Entities.UserCollege userCollege = new(
            command.UserId,
            command.CollegeId,
            command.StudentNumber,
            false,
            command.ProofDocument,
            command.GraduationDate
            );

            if (!userCollege.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", userCollege.Notifications);
            }

            _userCollegeRepository.Create(userCollege);

            return new GenericCommandsResult(true, "UserCollege created", userCollege.Id);
        }
    }
}
