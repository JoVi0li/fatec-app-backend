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
    public class UpdateUserCollegeGraduationDateCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserCollegeGraduationDateCommand(DateTime graduationDate, Guid id)
        {
            GraduationDate = graduationDate;
            Id = id;
        }

        public DateTime GraduationDate { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(GraduationDate, "GraduationDate", "GraduationDate cannot be null")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
