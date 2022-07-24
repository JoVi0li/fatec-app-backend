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
    public class UpdateUserCollegeStudentNumberCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserCollegeStudentNumberCommand(string studentNumber)
        {
            StudentNumber = studentNumber;
        }

        public string StudentNumber { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(StudentNumber, "StudentNumber", "StudentNumber cannot be empty")
            );
        }
    }
}
