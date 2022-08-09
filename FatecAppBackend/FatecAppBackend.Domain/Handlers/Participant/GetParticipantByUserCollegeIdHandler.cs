using FatecAppBackend.Domain.Commands.Participant;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Participant
{
    public class GetParticipantByUserCollegeIdHandler : Notifiable<Notification>, IHandlerCommand<GetParticipantByUserCollegeIdCommand>
    {
        private IParticipantRepository _participantRepository;

        public GetParticipantByUserCollegeIdHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public ICommandResult Execute(GetParticipantByUserCollegeIdCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var participants = _participantRepository.GetByEventId(command.UserCollegeId);

            if (participants == null)
            {
                return new GenericCommandsResult(false, "Participants not found", "Inform another UserCollegeId");
            }

            if (participants.ToList().Count == 0)
            {
                return new GenericCommandsResult(false, "Participants not found", "Inform another UserCollegeId");
            }

            return new GenericCommandsResult(true, "Participants found", participants);
        }
    }
}
