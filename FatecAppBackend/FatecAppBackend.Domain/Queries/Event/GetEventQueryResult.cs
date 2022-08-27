using FatecAppBackend.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.Event
{
    public class GetEventQueryResult
    {
        public GetEventQueryResult(Guid id, Guid eventOwnerId, string from, string to, string route, bool onlyWomen, DateTime timeToGo, EnStatus status, ICollection<Entities.Participant>? participants)
        {
            Id = id;
            EventOwnerId = eventOwnerId;
            From = from;
            To = to;
            Route = route;
            OnlyWomen = onlyWomen;
            TimeToGo = timeToGo;
            Status = status;
            Participants = participants;
        }

        public Guid Id { get; private set; }

        public Guid EventOwnerId { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public string Route { get; private set; }

        public bool OnlyWomen { get; private set; }

        public DateTime TimeToGo { get; private set; }

        public EnStatus Status { get; private set; }

        public ICollection<Entities.Participant>? Participants { get; private set; }
    }
}
