using FatecAppBackend.Shared.Commands;
using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.User
{
    public class UpdateUserIdentityDocumentNumberCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserIdentityDocumentNumberCommand(string identityDocumentNumber, Guid id)
        {
            IdentityDocumentNumber = identityDocumentNumber;
            Id = id;
        }

        public string IdentityDocumentNumber { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(IdentityDocumentNumber, "IdentityDocumentNumber", "IdentityDocumentNumber cannot be empty")
                    .IsCpf(IdentityDocumentNumber, "IdentityDocumentNumber", "Invalid IdentityDocumentNumber")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
