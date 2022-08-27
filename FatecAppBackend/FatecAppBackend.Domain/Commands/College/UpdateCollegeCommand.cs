using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.DTOs.College;
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
        public UpdateCollegeCommand(UpdateCollegeDTO college)
        {
            College = college;
        }

        public UpdateCollegeDTO College { get; set; }

        public void Execute()
        {

            if(College.Name != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(College.Name, "Name", "name cannot be empty")
                );
            }

            if(College.Course != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(College.Course, "Course", "Course cannot be empty")
                );
            }

            if(College.Localization != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(College.Localization, "Localization", "Localization cannot be empty")
                );
            }

            if (College.Time != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                );
            }

        }
    }
}
