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
    public class UpdateCollegeNameCommand : Notifiable<Notification>, ICommand
    {
        public UpdateCollegeNameCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        
        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Name, "Name", "Name cannot be empty")
            );
        }
    }
}
