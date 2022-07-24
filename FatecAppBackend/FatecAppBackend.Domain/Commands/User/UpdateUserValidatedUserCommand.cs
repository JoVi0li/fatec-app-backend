using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.User
{
    public class UpdateUserValidatedUserCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserValidatedUserCommand(bool validatedUser, Guid id)
        {
            ValidatedUser = validatedUser;
            Id = id;
        }

        public bool ValidatedUser { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(ValidatedUser, "ValidatedUser", "ValidatedUser cannot be null")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
