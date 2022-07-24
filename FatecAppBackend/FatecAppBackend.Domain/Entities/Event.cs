using FatecAppBackend.Shared;
using FatecAppBackend.Shared.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Entities
{
    public class Event : Base
    {
        public Event(
            Guid eventOwnerId,
            List<UserCollege> participants,
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
                    .IsNotNull(participants, "Participants", "Participants cannot be null")
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
                Participants = participants;
                From = from;
                To = to;
                Route = route;
                OnlyWomen = onlyWomen;
                TimeToGo = timeToGo;
                Status = status;
            } else
            {
                throw new Exception("Invalid Event props");
            }

        }

        public Guid EventOwnerId { get; private set; }
        public UserCollege EventOwner { get; private set; }

        public List<UserCollege> Participants { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public string Route { get; private set; }

        public bool OnlyWomen { get; private set; }

        public DateTime TimeToGo { get; private set; }

        public EnStatus Status { get; private set; }

        // Updates
        public void addParticipant(UserCollege newParticipant)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(newParticipant, "Participant", "Participant cannot be null")
            );

            if (IsValid)
            {
                bool participantAlreadyExits = Participants.Contains(newParticipant);

                if (participantAlreadyExits)
                {
                    throw new Exception("Participant already exits");
                } else
                {
                    Participants.Add(newParticipant);
                }
            }
            else
            {
                throw new Exception("Could not add a new Participant");
            }
        }

        public void removeParticipant(Guid participantId)
        {
            AddNotifications(
                new Contract<Notification>()
                     .Requires()
                     .IsNotNull(participantId, "Id", "Id cannot be null")
            );

            if (IsValid)
            {
                UserCollege? participant = Participants.FirstOrDefault(x => x.Id == participantId);

                if(participant == null)
                {
                    throw new Exception("Participant nonexistent");
                } else
                {
                    Participants.Remove(participant);
                }
            } else
            {
                throw new Exception("Could not remove a Participant");
            }
        }

        public void UpdateFrom(string newFrom)
        {
            AddNotifications(
                new Contract<Notification>()
                     .Requires()
                     .IsNotEmpty(newFrom, "From", "From cannot be empty")
                     .AreNotEquals(newFrom, From, "From", "New From cannot be equal the old From")
            );

            if (IsValid)
            {
                From = newFrom;
            } else
            {
                throw new Exception("Could not update From");
            }
        }

        public void UpdateTo(string newTo)
        {
            AddNotifications(
                new Contract<Notification>()
                     .Requires()
                     .IsNotEmpty(newTo, "To", "To cannot be empty")
                     .AreNotEquals(newTo, To, "To", "New To cannot be equal the old To")
            );

            if (IsValid)
            {
                To = newTo;
            }
            else
            {
                throw new Exception("Could not update To");
            }
        }

        public void UpdateRoute(string newRoute)
        {
            AddNotifications(
                new Contract<Notification>()
                     .Requires()
                     .IsNotEmpty(newRoute, "Route", "Route cannot be empty")
                     .AreNotEquals(newRoute, Route, "Route", "New Route cannot be equal the old Route")
            );

            if (IsValid)
            {
                Route = newRoute;
            }
            else
            {
                throw new Exception("Could not update Route");
            }
        }

        public void UpdateOnlyWomen(bool newOnlyWomen)
        {
            AddNotifications(
                new Contract<Notification>()
                     .Requires()
                     .IsNotNull(newOnlyWomen, "OnlyWomen", "OnlyWomen cannot be null")
                     .AreNotEquals(newOnlyWomen, OnlyWomen, "Route", "New OnlyWomen cannot be equal the old OnlyWomen")
            );

            if (IsValid)
            {
                OnlyWomen = newOnlyWomen;
            }
            else
            {
                throw new Exception("Could not update OnlyWomen");
            }
        }

        public void UpdateTimeToGo(DateTime newTimeToGo)
        {
            AddNotifications(
                new Contract<Notification>()
                     .Requires()
                     .IsNotNull(newTimeToGo, "TimeToGo", "TimeToGo cannot be null")
                     .AreNotEquals(newTimeToGo, TimeToGo, "TimeToGo", "New TimeToGo cannot be equal the old TimeToGo")
            );

            if (IsValid)
            {
                TimeToGo = newTimeToGo;
            }
            else
            {
                throw new Exception("Could not update TimeToGo");
            }
        }

        public void UpdateStatus(EnStatus newStatus)
        {
            AddNotifications(
                new Contract<Notification>()
                     .Requires()
                     .IsNotNull(newStatus, "Status", "Status cannot be null")
                     .AreNotEquals(newStatus, Status, "Status", "New Status cannot be equal the old Status")
            );

            if (IsValid)
            {
                Status = newStatus;
            }
            else
            {
                throw new Exception("Could not update Status");
            }
        }
    }
}
