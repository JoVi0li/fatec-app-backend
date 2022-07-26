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
        Event GetById(Guid id);

        /// <summary>
        /// Search an Event by name
        /// </summary>
        /// <param name="name">Event Name</param>
        /// <returns></returns>
        IReadOnlyCollection<Event> GetByName(string name);

        /// <summary>
        /// Delete a Event by Id
        /// </summary>
        /// <param name="id">Event Id</param>
        void Delete(Guid id);

        /// <summary>
        /// Add a participant to the Event
        /// </summary>
        /// <param name="participant">Participant props</param>
        void AddParticipant(UserCollege participant);

        /// <summary>
        /// Remove a participant from the Event
        /// </summary>
        /// <param name="id">Participant Id</param>
        void RemoveParticipant(Guid id);

        /// <summary>
        /// Updathe the From
        /// </summary>
        /// <param name="event">Event with the new From</param>
        void UpdateFrom(Event @event);

        /// <summary>
        /// Update the To
        /// </summary>
        /// <param name="event">Event with the new To</param>
        void UpdateTo(Event @event);
        
        /// <summary>
        /// Update the OnlyWomen
        /// </summary>
        /// <param name=event">Event with the new OnlyWomen</param>
        void UpdateOnlyWomen(Event @event);

        /// <summary>
        /// Update the Route
        /// </summary>
        /// <param name="event">Event with the new Route</param>
        void UpdateRoute(Event @event);

        /// <summary>
        /// Update the TimeToGo
        /// </summary>
        /// <param name="event">Event with the new TimeToGo</param>
        void UpdateTimeToGo(Event @event);

        /// <summary>
        /// Update the Status
        /// </summary>
        /// <param name="event">Event with the new Status</param>
        void UpdateStatus(Event @event);
    }
}
