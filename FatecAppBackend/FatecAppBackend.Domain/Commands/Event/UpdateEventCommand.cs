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
    public class UpdateEventCommand : Notifiable<Notification>, ICommand
    {
        public UpdateEventCommand(Guid id, string? from, string? to, string? route, bool? onlyWomen, DateTime? timeToGo, EnStatus? status)
        {
            Id = id;
            From = from;
            To = to;
            Route = route;
            OnlyWomen = onlyWomen;
            TimeToGo = timeToGo;
            Status = status;
        }

        public Guid Id { get; private set; }

        public string? From { get; private set; }

        public string? To { get; private set; }

        public string? Route { get; private set; }

        public bool? OnlyWomen { get; private set; }

        public DateTime? TimeToGo { get; private set; }

        public EnStatus? Status { get; private set; }

        public void Execute()
        {
            if(From != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(From, "From", "From cannot be empty")
                );
            }

            if(To != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(To, "To", "To cannot be empty")
                );
            }

            if (Route != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(Route, "Route", "Route cannot be empty")
                );
            }


            if (OnlyWomen != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(OnlyWomen, "OnlyWomen", "OnlyWomen cannot be null")
                );
            }

            if (TimeToGo != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(TimeToGo, "TimeToGo", "TimeToGo cannot be null")
                );
            }

            if (Status != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(Status, "Status", "Status cannot be null")
                );
            }
        }
    }
}
