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
    public class UpdateCollegeCourseCommand : Notifiable<Notification> , ICommand
    {
        public UpdateCollegeCourseCommand(string course)
        {
            Course = course;
        }

        public string Course { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Course, "Course", "Course cannot be empty")
            );
        }
    }
}
