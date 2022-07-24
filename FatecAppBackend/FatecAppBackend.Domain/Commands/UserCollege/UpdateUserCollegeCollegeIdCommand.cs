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
    public class UpdateUserCollegeCollegeIdCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserCollegeCollegeIdCommand(Guid collegeId)
        {
            CollegeId = collegeId;
        }

        public Guid CollegeId { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(CollegeId, "CollegeId", "CollegeId cannot be null")
            );
        }
    }
}
