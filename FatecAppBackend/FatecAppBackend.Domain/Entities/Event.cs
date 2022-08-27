using FatecAppBackend.Shared;
using FatecAppBackend.Shared.DTOs.Event;
using FatecAppBackend.Shared.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections;
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

        
        // Props

        public string From { get; private set; }

        public string To { get; private set; }

        public string Route { get; private set; }

        public bool OnlyWomen { get; private set; }

        public DateTime TimeToGo { get; private set; }

        public EnStatus Status { get; private set; }


        // Composition

        [ForeignKey("UserCollege")]
        public Guid EventOwnerId { get; private set; }
        public UserCollege EventOwner { get; private set; }

        public virtual ICollection<Participant> Participants { get; private set; }


        // Update

        public void Update(UpdateEventDTO @event)
        {
            if(@event.From != null)
            {
                if (@event.From.Length > 0 && @event.From != From)
                {
                    From = @event.From;
                }
                else
                {
                    AddNotification("From", "Could not update, invalid value");
                }
            }


            if (@event.To != null)
            {
                if (@event.To.Length > 0 && @event.To != To)
                {
                    To = @event.To;
                }
                else
                {
                    AddNotification("To", "Could not update, invalid value");
                }
            }
        

            if (@event.Route != null)
            {
                if (@event.Route.Length > 0 && @event.Route != Route)
                {
                    Route = @event.Route;
                }
                else
                {
                    AddNotification("Route", "Could not update, invalid value");
                }
            }

            if (@event.OnlyWomen != null)
            {
                if (@event.OnlyWomen != OnlyWomen && @event.OnlyWomen != OnlyWomen)
                {
                    OnlyWomen = (bool)@event.OnlyWomen;
                }
                else
                {
                    AddNotification("OnlyWomen", "Could not update, invalid value");
                }
            }


            if (@event.TimeToGo != null)
            {
                if (@event.TimeToGo != TimeToGo)
                {
                    TimeToGo = (DateTime)@event.TimeToGo;
                }
                else
                {
                    AddNotification("TimeToGo", "Could not update, invalid value");
                }
            }

            if (@event.Status != null)
            {
                if (@event.Status != Status)
                {
                    Status = (EnStatus)@event.Status;
                }
                else
                {
                    AddNotification("Status", "Could not update, invalid value");
                }
            }
        }

    }
}
