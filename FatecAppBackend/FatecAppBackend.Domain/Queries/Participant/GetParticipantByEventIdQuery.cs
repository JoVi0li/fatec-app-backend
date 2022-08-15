using FatecAppBackend.Shared.Handlers.Contracts;
using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.Participant
{
    public class GetParticipantByEventIdQuery : Notifiable<Notification>, IQuery
    {
        public GetParticipantByEventIdQuery(Guid eventId)
        {
            EventId = eventId;
        }

        public Guid EventId { get; private set; }

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
