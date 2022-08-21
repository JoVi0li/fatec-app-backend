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
        public virtual Event Event { get; set; }

        [ForeignKey("UserCollege")]
        public Guid UserCollegeId { get; set; }
        public virtual UserCollege UserCollege { get; set; }

    }
}
