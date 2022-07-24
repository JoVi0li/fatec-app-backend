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
    public class UpdateUserCollegeValidatedDocumentCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserCollegeValidatedDocumentCommand(bool validatedDocument)
        {
            ValidatedDocument = validatedDocument;
        }

        public bool ValidatedDocument { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(ValidatedDocument, "ValidatedDocument", "ValidatedDocument cannot be null")
            );
        }
    }
}
