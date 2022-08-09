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
    public class GetEventByIdHandler : Notifiable<Notification>, IHandlerCommand<GetEventByIdCommand>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByIdHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ICommandResult Execute(GetEventByIdCommand command)
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

            if (!@event.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", @event.Notifications);
            }

            return new GenericCommandsResult(true, "Event found", @event);
        }
    }
}
