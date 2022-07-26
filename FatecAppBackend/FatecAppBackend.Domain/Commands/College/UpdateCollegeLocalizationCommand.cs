﻿using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.College
{
    public class UpdateCollegeLocalizationCommand : Notifiable<Notification>, ICommand
    {
        public UpdateCollegeLocalizationCommand(string localization, Guid id)
        {
            Localization = localization;
            Id = id;
        }

        public string Localization { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Localization, "Localization", "Localization cannot be empty")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
