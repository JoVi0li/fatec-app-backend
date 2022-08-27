using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.DTOs.UserCollege;
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
        public UpdateUserCollegeCommand(UpdateUserCollegeDTO userCollege)
        {
            UserCollege = userCollege;
        }

        public UpdateUserCollegeDTO UserCollege { get; set; }

        public void Execute()
        {
            if(UserCollege.CollegeId != null)
            {
           
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(UserCollege.CollegeId, "CollegeId", "CollegeId cannot be null")
                );
            }

            if(UserCollege.StudentNumber != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(UserCollege.StudentNumber, "StudentNumber", "StudentNumber cannot be empty")
                );
            }

            if(UserCollege.ValidatedDocument != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(UserCollege.ValidatedDocument, "ValidatedDocument", "ValidatedDocument cannot be null")
                );
            }

            if(UserCollege.ProofDocument != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(UserCollege.ProofDocument, "ProofDocument", "ProofDocument cannot be empty")
                );
            }

            if(UserCollege.GraduationDate != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(UserCollege.GraduationDate, "GraduationDate", "GraduationDate cannot be null")
                );
            }
        }
    }
}
