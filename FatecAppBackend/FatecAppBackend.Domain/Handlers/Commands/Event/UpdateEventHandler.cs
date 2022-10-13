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

namespace FatecAppBackend.Domain.Handlers.Commands.Event
{
    public class UpdateEventHandler : Notifiable<Notification>, IHandlerCommand<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ICommandResult Execute(UpdateEventCommand command)
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

            @event.Update(command);

            if (!@event.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update, invalid props", @event.Notifications);
            }

            _eventRepository.Update(@event);

            return new GenericCommandsResult(true, "Event updated", @event.Id);
        }
    }
}
