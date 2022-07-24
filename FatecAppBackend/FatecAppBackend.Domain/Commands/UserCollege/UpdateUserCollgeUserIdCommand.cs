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
    public class UpdateUserCollgeUserIdCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserCollgeUserIdCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(UserId, "UserId", "UserId cannot be null")
            );
        }
    }
}
