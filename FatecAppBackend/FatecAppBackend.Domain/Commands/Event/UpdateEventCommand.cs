using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.DTOs.Event;
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
        public UpdateEventCommand(UpdateEventDTO @event)
        {
            Event = @event;
        }

        public UpdateEventDTO Event { get; set; }

        public void Execute()
        {
            if(Event.From != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(Event.From, "From", "From cannot be empty")
                );
            }

            if(Event.To != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(Event.To, "To", "To cannot be empty")
                );
            }

            if (Event.Route != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(Event.Route, "Route", "Route cannot be empty")
                );
            }


            if (Event.OnlyWomen != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(Event.OnlyWomen, "OnlyWomen", "OnlyWomen cannot be null")
                );
            }

            if (Event.TimeToGo != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(Event.TimeToGo, "TimeToGo", "TimeToGo cannot be null")
                );
            }

            if (Event.Status != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(Event.Status, "Status", "Status cannot be null")
                );
            }
        }
    }
}
