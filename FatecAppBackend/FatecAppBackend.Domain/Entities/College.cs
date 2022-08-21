using FatecAppBackend.Shared;
using FatecAppBackend.Shared.DTOs.College;
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


        // Props

        public string Name { get; private set; }

        public string Course { get; private set; }

        public EnTime Time { get; private set; }

        public string Localization { get; private set; }


        // Composition

        public virtual ICollection<UserCollege> UserCollege { get; set; }


        // Update

        public void Update(UpdateCollegeDTO college)
        {
            if(college.Name != null)
            {
                if(Name != college.Name)
                {
                    Name = college.Name;
                }
                else
                {
                    AddNotification("Name", "Could not update, invalid value");
                }
            } 

            if(college.Course != null )
            {
                if(Course != college.Course && college.Course.Length > 0)
                {
                    Course = college.Course;
                }
                else
                {
                    AddNotification("Course", "Could not update, invalid value");
                }
            }
  

            if (college.Time != null)
            {
                if(Time != college.Time)
                {
                    Time = (EnTime)college.Time;

                }
                else
                {
                    AddNotification("Time", "Could not update, invalid value");
                }
            }


            if (college.Localization != null )
            {
                if(college.Localization != Localization && college.Localization.Length > 0)
                {
                    Localization = college.Localization;
                }
                else
                {
                    AddNotification("Localization", "Could not update, invalid value");
                }
            }

        }

    }
}
