using FatecAppBackend.Domain.Queries.Event;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Handlers.Contracts;
using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Queries.Event
{
    public class GetEventByIdHandler : Notifiable<Notification>, IHandlerQuery<GetEventByIdQuery>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByIdHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IQueryResult Execute(GetEventByIdQuery query)
        {
            query.Execute();

            if (!IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var @event = _eventRepository.GetById(query.Id);

            if(@event == null)
            {
                return new GenericQueryResult(false, "Event not found", "Inform another Id");
            }

            var result = new GetEventQueryResult(@event.Id, @event.EventOwnerId, @event.From, @event.To, @event.Route, @event.OnlyWomen, @event.TimeToGo, @event.Status);

            return new GenericQueryResult(true, "College found", result);
        }
    }
}
