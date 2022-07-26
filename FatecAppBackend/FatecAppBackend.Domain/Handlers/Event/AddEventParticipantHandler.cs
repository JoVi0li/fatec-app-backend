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
    public class AddEventParticipantHandler : Notifiable<Notification>, IHandler<AddEventParticipantCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserCollegeRepository _userCollegeRepository;
        public AddEventParticipantHandler(IEventRepository eventRepository, IUserCollegeRepository userCollegeRepository)
        {
            _eventRepository = eventRepository;
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(AddEventParticipantCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var @event = _eventRepository.GetById(command.Id);

            if(@event == null)
            {
                return new GenericCommandsResult(false, "Event not found", "Inform another Id");
            }

            var participantAlreadyExists = @event.Participants.Any(x => x.Id == command.Participant.Id);

            if (participantAlreadyExists)
            {
                return new GenericCommandsResult(false, "Participant already exists", command.Notifications);
            }

            @event.AddParticipant(command.Participant);

            return new GenericCommandsResult(true, "Participant added", command.Participant.Id);
            
        }
    }
}
