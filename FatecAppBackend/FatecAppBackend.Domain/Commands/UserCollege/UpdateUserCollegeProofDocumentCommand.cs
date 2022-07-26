using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.UserCollege
{
    public class UpdateUserCollegeProofDocumentCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserCollegeProofDocumentCommand(string proofDocument, Guid id)
        {
            ProofDocument = proofDocument;
            Id = id;
        }

        public string ProofDocument { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(ProofDocument, "ProofDocument", "ProofDocument cannot be empty")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
