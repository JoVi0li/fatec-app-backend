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
    public class UpdateUserIdentityDocumentPhotoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserIdentityDocumentPhotoCommand(string identityDocumentPhoto, Guid id)
        {
            IdentityDocumentPhoto = identityDocumentPhoto;
            Id = id;
        }

        public string IdentityDocumentPhoto { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(IdentityDocumentPhoto, "IdentityDocumentPhoto", "IdentityDocumentPhoto cannot be empty")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
