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
        /// <param name="from">New From</param>
        void UpdateFrom(string from);

        /// <summary>
        /// Update the To
        /// </summary>
        /// <param name="to">New To</param>
        void UpdateTo(string to);
        
        /// <summary>
        /// Update the OnlyWomen
        /// </summary>
        /// <param name="onlyWomen">New OnlyWomen</param>
        void UpdateOnlyWomen(bool onlyWomen);

        /// <summary>
        /// Update the Route
        /// </summary>
        /// <param name="route">New Route</param>
        void UpdateRoute(string route);

        /// <summary>
        /// Update the TimeToGo
        /// </summary>
        /// <param name="timeToGo">New TimeToGo</param>
        void UpdateTimeToGo(DateTime timeToGo);

        /// <summary>
        /// Update the Status
        /// </summary>
        /// <param name="status">New Status</param>
        void UpdateStatus(EnStatus status);
    }
}
