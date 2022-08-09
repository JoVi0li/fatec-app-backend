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
    public class GetParticipantByIdHandler : Notifiable<Notification>, IHandlerCommand<GetParticipantByIdCommand>
    {
        private IParticipantRepository _participantRepository;

        public GetParticipantByIdHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public ICommandResult Execute(GetParticipantByIdCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var participant = _participantRepository.GetById(command.Id);

            if (participant == null)
            {
                return new GenericCommandsResult(false, "Participant not found", "Inform another Id");
            }

            if (!participant.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", participant.Notifications);
            }

            return new GenericCommandsResult(true, "Participant found", participant);

        }
    }
}
