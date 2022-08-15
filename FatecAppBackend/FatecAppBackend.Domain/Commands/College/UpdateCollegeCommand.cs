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
        public UpdateCollegeCommand(Entities.College college)
        {
            College = college;
        }

        public Entities.College College { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(College, "College", "College cannot be null")
            );
        }
    }
}
