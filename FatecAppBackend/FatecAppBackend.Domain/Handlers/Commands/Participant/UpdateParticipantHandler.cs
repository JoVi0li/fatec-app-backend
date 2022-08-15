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

namespace FatecAppBackend.Domain.Handlers.Commands.Participant
{
    public class UpdateParticipantHandler : Notifiable<Notification>, IHandlerCommand<UpdateParticipantCommand>
    {
        private readonly IParticipantRepository _participantRepository;

        public UpdateParticipantHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public ICommandResult Execute(UpdateParticipantCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var participant = _participantRepository.GetById(command.Participant.Id);

            if(participant == null)
            {
                return new GenericCommandsResult(false, "Participant not found", "Inform another Id");
            }

            participant.Update(command.Participant.EventId, command.Participant.UserCollegeId);

            if (!participant.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update, invalid props", participant.Notifications);
            }

            _participantRepository.Update(participant);

            return new GenericCommandsResult(true, "Participant updated", participant);
        }
    }
}
