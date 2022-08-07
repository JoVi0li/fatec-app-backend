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
    public class CreateEventHandler : Notifiable<Notification>, IHandler<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserCollegeRepository _userCollegeRepository;

        public CreateEventHandler(IEventRepository eventRepository, IUserCollegeRepository userCollegeRepository)
        {
            _eventRepository = eventRepository;
            _userCollegeRepository = userCollegeRepository;
        }

        public ICommandResult Execute(CreateEventCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var eventOwnerExists = _userCollegeRepository.GetById(command.EventOwnerId);

            if(eventOwnerExists == null)
            {
                return new GenericCommandsResult(false, "EventOwner not exists", "Inform another EventOwnerId");
            }

            Entities.Event @event = new(
                command.EventOwnerId,
                command.From,
                command.To,
                command.Route,
                command.OnlyWomen,
                command.TimeToGo,
                command.Status
            );

            if (!@event.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", @event.Notifications);
            }

            _eventRepository.Create(@event);

            return new GenericCommandsResult(true, "Event created", @event.Id);
        }
    }
}
