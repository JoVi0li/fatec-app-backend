using FatecAppBackend.Shared;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Entities
{
    public class Participant : Base
    {
        public Participant()
        {

        }

        public Participant(Guid eventId, Guid userCollegeId)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(eventId, "EventId", "EventId cannot be null")
                    .IsNotNull(userCollegeId, "UserCollegeId", "UserCollegeId cannot be null")
            );

            if (IsValid)
            {
                EventId = eventId;
                UserCollegeId = userCollegeId;
            }
            else
            {
                AddNotification("Participant", "Invalid Participant props");
            }
        }

        [ForeignKey("Event")]
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        [ForeignKey("UserCollege")]
        public Guid UserCollegeId { get; set; }
        public UserCollege UserCollege { get; set; }


        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="eventId">New EventId</param>
        /// <param name="userCollegeId">New UserCollegeId</param>
        public void Update(Guid? eventId, Guid? userCollegeId)
        {
            if(eventId != null && eventId != EventId)
            {
                EventId = (Guid)eventId;
            }
            else
            {
                AddNotification("EventId", "Could not update, invalid value");
            }

            if (userCollegeId != null && userCollegeId != UserCollegeId)
            {
                UserCollegeId = (Guid)userCollegeId;
            }
            else
            {
                AddNotification("UserCollegeId", "Could not update, invalid value");
            }

        }
    }
}
