using FatecAppBackend.Shared;
using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.College
{
    public class UpdateCollegeCommand : Notifiable<Notification>, ICommand
    {
        public UpdateCollegeCommand(Guid id, string? name, string? course, EnTime? time, string? localization)
        {
            Id = id;
            Name = name;
            Course = course;
            Time = time;
            Localization = localization;
        }

        public Guid Id { get; private set; }

        public string? Name { get; private set; }

        public string? Course { get; private set; }

        public EnTime? Time { get; private set; }

        public string? Localization { get; private set; }


        public void Execute()
        {

            if(Name != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(Name, "Name", "name cannot be empty")
                );
            }

            if(Course != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(Course, "Course", "Course cannot be empty")
                );
            }

            if(Localization != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(Localization, "Localization", "Localization cannot be empty")
                );
            }

            if (Time != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(Time, "Time", "Time cannot be null")
                );
            }

        }
    }
}
