using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Authentication
{
    public class ChangePasswordCommand : Notifiable<Notification>, ICommand
    {
        public ChangePasswordCommand(Entities.User user)
        {
            User = user;
        }

        public Entities.User User { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(User, "User", "User cannot be null")
            );
        }
    }
}
