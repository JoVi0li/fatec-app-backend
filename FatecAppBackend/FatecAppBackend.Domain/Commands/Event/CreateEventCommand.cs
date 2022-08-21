using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Event
{
    public class CreateEventCommand : Notifiable<Notification>, ICommand
    {
        public CreateEventCommand(Guid eventOwnerId, string from, string to, string route, bool onlyWomen, string timeToGo, EnStatus status)
        {
            EventOwnerId = eventOwnerId;
            From = from;
            To = to;
            Route = route;
            OnlyWomen = onlyWomen;
            TimeToGo = timeToGo;
            Status = status;
        }

        public Guid EventOwnerId { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public string Route { get; private set; }

        public bool OnlyWomen { get; private set; }

        public string TimeToGo { get; private set; }

        public EnStatus Status { get; private set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(EventOwnerId, "EventOwnerId", "EventOwnerId cannot be null")
                    .IsNotEmpty(From, "From", "From cannot be empty")
                    .IsNotEmpty(To, "To", "To cannot be empty")
                    .IsNotEmpty(Route, "Route", "Route cannot be empty")
                    .IsNotNull(OnlyWomen, "OnlyWomen", "OnlyWomen cannot be null")
                    .IsNotEmpty(TimeToGo, "TimeToGo", "TimeToGo cannot be empty")
                    .IsNotNull(Status, "Status", "Status cannot be null")
            );
        }
    }
}
