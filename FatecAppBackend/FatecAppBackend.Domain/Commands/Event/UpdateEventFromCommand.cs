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
    public class UpdateEventFromCommand : Notifiable<Notification>, ICommand
    {
        public UpdateEventFromCommand(string from, Guid id)
        {
            From = from;
            Id = id;
        }

        public string From { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(From, "From", "From cannot be null")
            );
        }
    }
}
