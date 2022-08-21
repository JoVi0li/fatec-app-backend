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
    public class GetEventHandler : Notifiable<Notification>, IHandlerQuery<GetEventQuery>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IQueryResult Execute(GetEventQuery query)
        {
            var events = _eventRepository.GetAll();

            if(events == null || events.Count == 0)
            {
                return new GenericQueryResult(false, "Events not found", 0);
            }

            var result = events.Select(
                x =>
                {
                    return new GetEventQueryResult(x.Id, x.EventOwnerId, x.From, x.To, x.Route, x.OnlyWomen, x.TimeToGo, x.Status, x.Participants);
                }
            );

            return new GenericQueryResult(true, "Events found", result);
        }
    }
}
