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
    public class UpdateEventTimeToGoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateEventTimeToGoCommand(DateTime timeToGo)
        {
            TimeToGo = timeToGo;
        }

        public DateTime TimeToGo { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(TimeToGo, "TimeToGo", "TimeToGo cannot be null")
            );
        }
    }
}
