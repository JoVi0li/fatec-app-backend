﻿using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Event
{
    public class AddEventParticipantCommand : Notifiable<Notification>, ICommand
    {
        public AddEventParticipantCommand(Entities.UserCollege participant)
        {
            Participant = participant;
        }

        public Entities.UserCollege Participant { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Participant, "Participant", "Participant cannot be null")
            );
        }
    }
}
