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
    public class UpdateEventToHandler : Notifiable<Notification>, IHandler<UpdateEventToCommand>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventToHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ICommandResult Execute(UpdateEventToCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var @event = _eventRepository.GetById(command.Id);

            if(@event == null)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            @event.UpdateTo(command.To);

            if (!@event.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update To", @event.Notifications);
            }

            _eventRepository.UpdateTo(@event);

            return new GenericCommandsResult(true, "To updated", @event.To);
        }
    }
}
