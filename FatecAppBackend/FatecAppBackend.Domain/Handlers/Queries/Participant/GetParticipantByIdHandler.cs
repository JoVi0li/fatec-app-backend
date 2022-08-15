using FatecAppBackend.Domain.Queries.Participant;
using FatecAppBackend.Domain.Repositories;
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
    public class GetParticipantByIdHandler : Notifiable<Notification>, IHandlerQuery<GetParticipantByIdQuery>
    {
        private IParticipantRepository _participantRepository;

        public GetParticipantByIdHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public IQueryResult Execute(GetParticipantByIdQuery query)
        {
            query.Execute();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var participant = _participantRepository.GetById(query.Id);

            if (participant == null)
            {
                return new GenericQueryResult(false, "Participant not found", "Inform another Id");
            }

            if (!participant.IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", participant.Notifications);
            }

            var result = new GetParticipantQueryResult(participant.UserCollegeId, participant.EventId, participant.UserCollege.UserId, participant.UserCollege.CollegeId, participant.Event.EventOwnerId, participant.UserCollege.StudentNumber, participant.UserCollege.GraduationDate, participant.Event.From, participant.Event.To, participant.Event.Route, participant.Event.OnlyWomen, participant.Event.TimeToGo, participant.Event.Status);

            return new GenericQueryResult(true, "Participant found", result);

        }
    }
}
