using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Participant
{
    public class GetParticipantByEventIdCommand : Notifiable<Notification>, ICommand
    {
        public GetParticipantByEventIdCommand(Guid eventId)
        {
            EventId = eventId;
        }

        public Guid EventId { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(EventId, "EventId", "EventId cannot be null")
            );
        }
    }
}
