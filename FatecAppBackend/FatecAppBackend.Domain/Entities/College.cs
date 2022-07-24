using FatecAppBackend.Shared;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain
{
    public class College : Base
    {
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
                throw new Exception("Invalid College props");
            }
        }

        public string Name { get; private set; }

        public string Course { get; private set; }

        public EnTime Time { get; private set; }

        public string Localization { get; private set; }

        public IReadOnlyCollection<UserCollege> UserCollege { get; set; }


        //Updates

        public void UpdateName(string newName)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(newName, "Name", "Name cannot be empty")
                    .AreNotEquals(newName, Name, "Name", "New Name cannot be equal the old Name")
            );

            if (IsValid)
            {
                Name = newName;
            } else
            {
                throw new Exception("Could not update Name");
            }
        }

        public void UpdateCourse(string newCourse)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(newCourse, "Course", "Course cannot be empty")
                    .AreNotEquals(newCourse, Course, "Course", "New Course cannot be equal the old Course")
            );

            if (IsValid)
            {
                Course = newCourse;
            }
            else
            {
                throw new Exception("Could not update Course");
            }
        }


        public void UpdateTime(EnTime newTime)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(newTime, "Time", "Time cannot be empty")
                    .AreNotEquals(newTime, Time, "Time", "New Time cannot be equal the old Time")
            );

            if (IsValid)
            {
                Time = newTime;
            }
            else
            {
                throw new Exception("Could not update Time");
            }
        }

        public void UpdateLocalization(string newLocalization)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(newLocalization, "Localization", "Localization cannot be empty")
                    .AreNotEquals(newLocalization, Localization, "Localization", "New Localization cannot be equal the old Localization")
            );

            if (IsValid)
            {
                Localization = newLocalization;
            }
            else
            {
                throw new Exception("Could not update Localization");
            }
        }

    }
}
