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
    public class UpdateEventOnlyWomenHandler : Notifiable<Notification>, IHandlerCommand<UpdateEventOnlyWomenCommand>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventOnlyWomenHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ICommandResult Execute(UpdateEventOnlyWomenCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invali props", command.Notifications);
            }

            var @event = _eventRepository.GetById(command.Id);

            if(@event == null)
            {
                return new GenericCommandsResult(false, "Event not found", "Inform another Id");
            }

            @event.UpdateOnlyWomen(command.OnlyWomen);

            if (!@event.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update OnlyWomen", @event.Notifications);
            }

            _eventRepository.UpdateOnlyWomen(@event);

            return new GenericCommandsResult(true, "OnlyWomen updated", @event.OnlyWomen);
        }
    }
}
