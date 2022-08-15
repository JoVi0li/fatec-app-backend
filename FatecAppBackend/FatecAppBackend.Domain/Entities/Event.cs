using FatecAppBackend.Shared;
using FatecAppBackend.Shared.Enums;
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
    public class Event : Base
    {
        public Event()
        {

        }

        public Event(
            Guid eventOwnerId,
            string from,
            string to,
            string route,
            bool onlyWomen,
            DateTime timeToGo,
            EnStatus status
        )
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(eventOwnerId, "EventOwnerId", "EventOwnerId cannot be null")
                    .IsNotEmpty(from, "From", "From cannot be empty")
                    .IsNotEmpty(to, "To", "To cannot be empty")
                    .IsNotEmpty(route, "Route", "Route cannot be empty")
                    .IsNotNull(onlyWomen, "OnlyWomen", "OnlyWomen cannot be null")
                    .IsNotNull(timeToGo, "TimeToGo", "TimeToGo cannot be null")
                    .IsNotNull(status, "Status", "Status cannot be null")
            );

            if (IsValid)
            {
                EventOwnerId = eventOwnerId;
                From = from;
                To = to;
                Route = route;
                OnlyWomen = onlyWomen;
                TimeToGo = timeToGo;
                Status = status;
            } else
            {
                AddNotification("Event", "Invalid Event props");
            }

        }

        [ForeignKey("UserCollege")]
        public Guid EventOwnerId { get; private set; }
        public UserCollege EventOwner { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public string Route { get; private set; }

        public bool OnlyWomen { get; private set; }

        public DateTime TimeToGo { get; private set; }

        public EnStatus Status { get; private set; }

        public virtual ICollection<Participant> Participants { get; set; }


        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="from">New From</param>
        /// <param name="to">New To</param>
        /// <param name="route">New Route</param>
        /// <param name="onlyWomen">New OnlyWomen</param>
        /// <param name="timeToGo">New TimeToGo</param>
        /// <param name="status">New Status</param>
        public void Update(string? from, string? to, string? route, bool? onlyWomen, DateTime? timeToGo, EnStatus? status)
        {
            if(from != null && from.Length > 0 && from != From)
            {
                From = from;
            }
            else
            {
                AddNotification("From", "Could not update, invalid value");
            }

            if (to != null && to.Length > 0 && to != To)
            {
                To = to;
            }
            else
            {
                AddNotification("To", "Could not update, invalid value");
            }

            if (route != null && route.Length > 0 && route != Route)
            {
                Route = route;
            }
            else
            {
                AddNotification("Route", "Could not update, invalid value");
            }

            if (onlyWomen != null && onlyWomen != OnlyWomen && onlyWomen != OnlyWomen)
            {
                OnlyWomen = (bool)onlyWomen;
            }
            else
            {
                AddNotification("OnlyWomen", "Could not update, invalid value");
            }

            if (timeToGo != null && timeToGo != TimeToGo)
            {
                TimeToGo = (DateTime)timeToGo;
            }
            else
            {
                AddNotification("TimeToGo", "Could not update, invalid value");
            }

            if (status != null && status != Status)
            {
                Status = (EnStatus)status;
            }
            else
            {
                AddNotification("Status", "Could not update, invalid value");
            }
        }

    }
}
