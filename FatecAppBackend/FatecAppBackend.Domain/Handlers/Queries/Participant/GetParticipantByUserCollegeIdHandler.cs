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
    public class GetParticipantByUserCollegeIdHandler : Notifiable<Notification>, IHandlerQuery<GetParticipantByUserCollegeIdQuery>
    {
        private IParticipantRepository _participantRepository;

        public GetParticipantByUserCollegeIdHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public IQueryResult Execute(GetParticipantByUserCollegeIdQuery query)
        {
            query.Execute();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var participants = _participantRepository.GetByUserCollegeId(query.UserCollegeId);

            if (participants == null)
            {
                return new GenericQueryResult(false, "Participants not found", "Inform another UserCollegeId");
            }

            if (participants.ToList().Count == 0)
            {
                return new GenericQueryResult(false, "Participants not found", "Inform another UserCollegeId");
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
