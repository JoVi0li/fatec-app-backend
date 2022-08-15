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
    public class GetEventByNameHandler : Notifiable<Notification>, IHandlerQuery<GetEventByNameQuery>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByNameHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IQueryResult Execute(GetEventByNameQuery query)
        {
            query.Execute();

            if (!IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var events = _eventRepository.GetByName(query.Name);

            if (events == null || events.Count == 0)
            {
                return new GenericQueryResult(false, "Event not found", "Inform another Name");
            }

            var result = events.Select(
                x =>
                {
                    return new GetEventQueryResult(x.Id, x.EventOwnerId, x.From, x.To, x.Route, x.OnlyWomen, x.TimeToGo, x.Status);
                }
            );

            return new GenericQueryResult(true, "College found", result);
        }
    }
}
