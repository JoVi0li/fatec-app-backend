using FatecAppBackend.Shared;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Entities
{
    public class College : Base
    {
        public College()
        {

        }

        public College(string name, string course, EnTime time, string localization)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(name, "Name", "name cannot be empty")
                    .IsNotEmpty(course, "Course", "Course cannot be empty")
                    .IsNotNull(time, "Time", "Time cannot be null")
                    .IsNotEmpty(localization, "Localization", "Localization cannot be empty")
            );

            if (IsValid)
            {
                Name = name;
                Course = course;
                Time = time;
                Localization = localization;
            } else
            {
                AddNotification("College", "Invalid College props");
            }
        }

        public string Name { get; private set; }

        public string Course { get; private set; }

        public EnTime Time { get; private set; }

        public string Localization { get; private set; }

        public IReadOnlyCollection<UserCollege> UserCollege { get; set; }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="name">New Name</param>
        /// <param name="course">New Course</param>
        /// <param name="time">New Time</param>
        /// <param name="localization">New Localization</param>
        public void Update(string? name, string? course, EnTime? time, string? localization)
        {
            if(name != null && name.Length > 0 && name != Name)
            {
                Name = name;
            } 
            else
            {
                AddNotification("Name", "Could not update, invalid value");
            }

            if(course != null && course.Length > 0 && course != Course)
            {
                Course = course;
            }
            else
            {
                AddNotification("Course", "Could not update, invalid value");
            }

            if (time != null && time != Time && time != Time)
            {
                Time = (EnTime)time;
            }
            else
            {
                AddNotification("Time", "Could not update, invalid value");
            }

            if (localization != null && localization.Length > 0 && localization != Localization)
            {
                Localization = localization;
            }
            else
            {
                AddNotification("Localization", "Could not update, invalid value");
            }
        }

    }
}
