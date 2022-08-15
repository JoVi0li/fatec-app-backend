using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.UserCollege
{
    public class UpdateUserCollegeCommand : Notifiable<Notification> , ICommand
    {
        public UpdateUserCollegeCommand(Entities.UserCollege userCollege)
        {
            UserCollege = userCollege;
        }

        public Entities.UserCollege UserCollege { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(UserCollege, "UserCollege", "UserCollege cannot be null")
            );
        }
    }
}
