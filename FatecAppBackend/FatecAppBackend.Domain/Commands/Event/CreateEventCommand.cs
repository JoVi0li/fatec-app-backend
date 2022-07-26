﻿using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Event
{
    public class CreateEventCommand : Notifiable<Notification>, ICommand
    {
        public CreateEventCommand(Guid eventOwnerId, List<Entities.UserCollege> participants, string from, string to, string route, bool onlyWomen, DateTime timeToGo, EnStatus status)
        {
            EventOwnerId = eventOwnerId;
            Participants = participants;
            From = from;
            To = to;
            Route = route;
            OnlyWomen = onlyWomen;
            TimeToGo = timeToGo;
            Status = status;
        }

        public Guid EventOwnerId { get; private set; }

        public List<Entities.UserCollege> Participants { get; set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public string Route { get; private set; }

        public bool OnlyWomen { get; private set; }

        public DateTime TimeToGo { get; private set; }

        public EnStatus Status { get; private set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(EventOwnerId, "EventOwnerId", "EventOwnerId cannot be null")
                    .IsNotNull(Participants, "Participants", "Participants cannot be null")
                    .IsNotEmpty(From, "From", "From cannot be empty")
                    .IsNotEmpty(To, "To", "To cannot be empty")
                    .IsNotEmpty(Route, "Route", "Route cannot be empty")
                    .IsNotNull(OnlyWomen, "OnlyWomen", "OnlyWomen cannot be null")
                    .IsNotNull(TimeToGo, "TimeToGo", "TimeToGo cannot be null")
                    .IsNotNull(Status, "Status", "Status cannot be null")
            );
        }
    }
}
