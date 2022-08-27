using FatecAppBackend.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.Participant
{
    public class GetParticipantQueryResult
    {
        public GetParticipantQueryResult(Guid userCollegeId, Guid eventId, Guid userId, Guid collegeId, Guid eventOwnerId, string studentNumber, DateTime graduationDate, string from, string to, string route, bool onlyWomen, DateTime timeToGo, EnStatus status)
        {
            UserCollegeId = userCollegeId;
            EventId = eventId;
            UserId = userId;
            CollegeId = collegeId;
            EventOwnerId = eventOwnerId;
            StudentNumber = studentNumber;
            GraduationDate = graduationDate;
            From = from;
            To = to;
            Route = route;
            OnlyWomen = onlyWomen;
            TimeToGo = timeToGo;
            Status = status;
        }

        public Guid UserCollegeId { get; private set; }

        public Guid EventId { get; private set; }

        public Guid UserId { get; private set; }

        public Guid CollegeId { get; private set; }

        public Guid EventOwnerId { get; private set; }

        public string StudentNumber { get; private set; }

        public DateTime GraduationDate { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public string Route { get; private set; }

        public bool OnlyWomen { get; private set; }

        public DateTime TimeToGo { get; private set; }

        public EnStatus Status { get; private set; }

    }
}
