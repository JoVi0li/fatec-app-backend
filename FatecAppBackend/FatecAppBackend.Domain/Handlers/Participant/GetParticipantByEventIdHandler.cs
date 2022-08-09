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
    public class GetParticipantByEventIdHandler : Notifiable<Notification>, IHandlerCommand<GetParticipantByEventIdCommand>
    {
        private IParticipantRepository _participantRepository;

        public GetParticipantByEventIdHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public ICommandResult Execute(GetParticipantByEventIdCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var participants = _participantRepository.GetByEventId(command.EventId);

            if (participants == null)
            {
                return new GenericCommandsResult(false, "Participants not found", "Inform another EventId");
            }

            if (participants.ToList().Count == 0)
            {
                return new GenericCommandsResult(false, "Participants not found", "Inform another EventId");
            }

            return new GenericCommandsResult(true, "Participants found", participants);
        }
    }
}
