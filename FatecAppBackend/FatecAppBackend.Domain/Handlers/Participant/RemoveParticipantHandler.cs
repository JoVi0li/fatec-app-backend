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
    public class RemoveParticipantHandler : Notifiable<Notification>, IHandlerCommand<RemoveParticipantCommand>
    {
        private IParticipantRepository _participantRepository;

        public RemoveParticipantHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }
        public ICommandResult Execute(RemoveParticipantCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var participant = _participantRepository.GetById(command.ParticipantId);

            if(participant == null)
            {
                return new GenericCommandsResult(false, "Participant not found", "Inform another Id");
            }

            _participantRepository.Remove(participant.Id);

            return new GenericCommandsResult(true, "Participant removed", participant.Id);
        }
    }
}
