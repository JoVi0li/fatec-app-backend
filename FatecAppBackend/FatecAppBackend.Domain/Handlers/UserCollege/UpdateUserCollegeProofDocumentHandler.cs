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
    public class UpdateUserCollegeProofDocumentHandler : Notifiable<Notification>, IHandler<UpdateUserCollegeProofDocumentCommand>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public UpdateUserCollegeProofDocumentHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(UpdateUserCollegeProofDocumentCommand command)
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

            userCollege.UpdateProofDocument(command.ProofDocument);

            if (!userCollege.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update ProofDocument", userCollege.Notifications);
            }

            _userCollegeRepository.UpdateProofDocument(userCollege);

            return new GenericCommandsResult(true, "ProofDocument updated", userCollege.ProofDocument);
        }
    }
}
