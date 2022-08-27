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
    public class CreateCollegeCommand : Notifiable<Notification>, ICommand
    {
        public CreateCollegeCommand(string name, string course, EnTime time, string localization)
        {

            Name = name;
            Course = course;
            Time = time;
            Localization = localization;
        }

        public string Name { get; set; }

        public string Course { get; set; }

        public EnTime Time { get; set; }

        public string Localization { get; set; }


        public void Execute()
        {
            AddNotifications(
                 new Contract<Notification>()
                     .Requires()
                     .IsNotEmpty(Name, "Name", "name cannot be empty")
                     .IsNotEmpty(Course, "Course", "Course cannot be empty")
                     .IsNotNull(Time, "Time", "Time cannot be null")
                     .IsNotEmpty(Localization, "Localization", "Localization cannot be empty")
             );
        }
    }
}
