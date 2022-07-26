using FatecAppBackend.Domain.Commands.Event;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Event
{
    public class RemoveEventParticipantHandler : Notifiable<Notification>, IHandler<RemoveEventParticipantCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserCollegeRepository _userCollegeRepository;
        public RemoveEventParticipantHandler(IEventRepository eventRepository, IUserCollegeRepository userCollegeRepository)
        {
            _eventRepository = eventRepository;
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(RemoveEventParticipantCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var participant = _userCollegeRepository.GetById(command.IdParticipant);

            if(participant == null)
            {
                return new GenericCommandsResult(false, "Participant not found", "Inform anoher IdParticipant");
            }

            var @event = _eventRepository.GetById(command.Id);

            if(@event == null)
            {
                return new GenericCommandsResult(false, "Event not found", "Inform another Id");
            }

            var participantAlreadyInEvent = @event.Participants.Any(x => x.Id == participant.Id);

            if (!participantAlreadyInEvent)
            {
                return new GenericCommandsResult(false, "UserCollege not found in Event", "Inform another IdParticipant");
            }

            if (!participant.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", participant.Notifications);
            }

            if (!@event.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", @event.Notifications);
            }

            _eventRepository.RemoveParticipant(@event.Id);

            return new GenericCommandsResult(true, "Participant removed", @event.Id);
        }
    }
}
