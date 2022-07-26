﻿using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Event
{
    public class RemoveEventParticipantCommand : Notifiable<Notification>, ICommand
    {
        public RemoveEventParticipantCommand(Guid idEvent, Guid idParticipant)
        {
            Id = idEvent;
            IdParticipant = idParticipant;
        }

        public Guid Id { get; set; }
        public Guid IdParticipant { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Id, "Id", "Id cannot be null")
                    .IsNotNull(IdParticipant, "IdParticipant", "IdParticipant cannot be null")

            );
        }
    }
}
