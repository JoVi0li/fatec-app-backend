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
    public class UpdateEventRouteCommand : Notifiable<Notification>, ICommand
    {
        public UpdateEventRouteCommand(string route)
        {
            Route = route;
        }

        public string Route { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Route, "Route", "Route cannot be empty")
            );
        }
    }
}
