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
    public class UpdateEventStatusHandler : Notifiable<Notification>, IHandler<UpdateEventStatusCommand>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventStatusHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ICommandResult Execute(UpdateEventStatusCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            var @event = _eventRepository.GetById(command.Id);

            if(@event == null)
            {
                return new GenericCommandsResult(false, "Invalid props", "Inform another Id");
            }

            @event.UpdateStatus(command.Status);

            if (!@event.IsValid)
            {
                return new GenericCommandsResult(false, "Could not update Status", @event.Notifications);
            }

            _eventRepository.UpdateStatus(@event);

            return new GenericCommandsResult(true, "Status updated", @event.Status);
        }
    }
}
