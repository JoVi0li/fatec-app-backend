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
    public class CreateParticipantHandler : Notifiable<Notification>, IHandlerCommand<CreateParticipantCommand>
    {
        private IParticipantRepository _participantRepository;

        public CreateParticipantHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public ICommandResult Execute(CreateParticipantCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var @events = _participantRepository.GetByEventId(command.EventId);
            var userColleges = _participantRepository.GetByUserCollegeId(command.UserCollegeId);

            foreach(var e in @events)
            {
                foreach(var u in userColleges)
                {
                    if(e.Id == u.Id)
                    {
                        return new GenericCommandsResult(false, "Participant already exists", command.Notifications);
                    }
                }
            }

            Entities.Participant newParticipant = new(
                command.EventId,
                command.UserCollegeId
            );

            if (!newParticipant.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", newParticipant.Notifications);
            }

            _participantRepository.Create(newParticipant);

            return new GenericCommandsResult(true, "Participant created", newParticipant.Id);
        }
    }
}
