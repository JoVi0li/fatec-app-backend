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
    public class RemoveEventHandler : Notifiable<Notification>, IHandler<RemoveEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public RemoveEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ICommandResult Execute(RemoveEventCommand command)
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

            _eventRepository.Delete(@event.Id);

            return new GenericCommandsResult(true, "Event removed", @event.Id);
        }
    }
}
