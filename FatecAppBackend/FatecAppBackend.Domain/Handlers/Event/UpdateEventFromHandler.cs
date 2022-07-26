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
    public class UpdateEventFromHandler : Notifiable<Notification>, IHandler<UpdateEventFromCommand>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventFromHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ICommandResult Execute(UpdateEventFromCommand command)
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

            @event.UpdateFrom(command.From);

            if (!@event.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update From", @event.Notifications);
            }

            _eventRepository.UpdateFrom(@event);

            return new GenericCommandsResult(true, "From updated", @event.From);
        }
    }
}
