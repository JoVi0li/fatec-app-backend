using FatecAppBackend.Domain.Entities;
using FatecAppBackend.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Repositories
{
    public interface IEventRepository
    {
        /// <summary>
        /// Create a new Event
        /// </summary>
        /// <param name="event">Event props</param>
        void Create(Event @event);

        /// <summary>
        /// Get a list of all Events
        /// </summary>
        /// <returns>A list of Events</returns>
        ICollection<Event> GetAll();

        /// <summary>
        /// Search an Event by Id
        /// </summary>
        /// <param name="id">Event Id</param>
        /// <returns>An Event</returns>
        Event? GetById(Guid id);

        /// <summary>
        /// Delete an Event by Id
        /// </summary>
        /// <param name="id">Event Id</param>
        void Delete(Guid id);

        /// <summary>
        /// Update an Event
        /// </summary>
        /// <param name="event">Event props</param>
        void Update(Event @event);
    }
}
