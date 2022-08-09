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
    public class UpdateUserCollegeValidatedDocumentHandler : Notifiable<Notification>, IHandlerCommand<UpdateUserCollegeValidatedDocumentCommand>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public UpdateUserCollegeValidatedDocumentHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(UpdateUserCollegeValidatedDocumentCommand command)
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

            userCollege.UpdateValidatedDocument(command.ValidatedDocument);

            if (!userCollege.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update ValidatedDocument", userCollege.Notifications);
            }

            _userCollegeRepository.UpdateValidatedUser(userCollege);

            return new GenericCommandsResult(true, "ValidatedDocument updated", userCollege.ValidatedDocument);
        }
    }
}
