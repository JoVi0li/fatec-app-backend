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
    public class GetEventByNameHandler : Notifiable<Notification>, IHandler<GetEventByNameCommand>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByNameHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ICommandResult Execute(GetEventByNameCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var @events = _eventRepository.GetByName(command.Name);

            if(events.Count() == 0)
            {
                return new GenericCommandsResult(false, "Event not found", "Inform another Name");
            }

            foreach(var @event in @events)
            {
                if (!@event.IsValid)
                {
                    return new GenericCommandsResult(false, "Invalid props", @event.Notifications);
                }
            }

            return new GenericCommandsResult(true, "Events found", @events);
        }
    }
}
