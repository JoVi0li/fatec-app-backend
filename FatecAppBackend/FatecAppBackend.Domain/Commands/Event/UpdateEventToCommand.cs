using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Event
{
    public class UpdateEventToCommand : Notifiable<Notification>, ICommand
    {
        public UpdateEventToCommand(string to)
        {
            To = to;
        }

        public string To { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(To, "To", "To cannot be empty")
            );
        }
    }
}
