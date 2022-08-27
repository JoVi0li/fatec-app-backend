using FatecAppBackend.Domain.Commands.Participant;
using FatecAppBackend.Domain.Queries.Participant;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Queries.Participant
{
    public class GetParticipantByEventIdHandler : Notifiable<Notification>, IHandlerQuery<GetParticipantByEventIdQuery>
    {
        private IParticipantRepository _participantRepository;

        public GetParticipantByEventIdHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public IQueryResult Execute(GetParticipantByEventIdQuery query)
        {
            query.Execute();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var participants = _participantRepository.GetByEventId(query.EventId);

            if (participants == null)
            {
                return new GenericQueryResult(false, "Participants not found", "Inform another EventId");
            }

            if (participants.ToList().Count == 0)
            {
                return new GenericQueryResult(false, "Participants not found", "Inform another EventId");
            }

            var result = participants.Select(
                x =>
                {
                    return new GetParticipantQueryResult(x.UserCollegeId, x.EventId, x.UserCollege.UserId, x.UserCollege.CollegeId, x.Event.EventOwnerId, x.UserCollege.StudentNumber, x.UserCollege.GraduationDate, x.Event.From, x.Event.To, x.Event.Route, x.Event.OnlyWomen, x.Event.TimeToGo, x.Event.Status);
                }
            );

            return new GenericQueryResult(true, "Participants found", result);
        }


    }
}
