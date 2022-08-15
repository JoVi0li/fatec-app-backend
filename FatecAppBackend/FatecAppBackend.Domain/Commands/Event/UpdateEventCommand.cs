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
    public class UpdateEventCommand : Notifiable<Notification>, ICommand
    {
        public UpdateEventCommand(Entities.Event @event)
        {
            Event = @event;
        }

        public Entities.Event Event { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Event, "Event", "Event cannot be null")
            );
        }
    }
}
