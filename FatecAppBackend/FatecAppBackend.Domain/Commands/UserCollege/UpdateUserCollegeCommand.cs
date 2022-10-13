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
        public UpdateUserCollegeCommand(Guid id, Guid? collegeId, string? studentNumber, bool? validatedDocument, string? proofDocument, string? graduationDate)
        {
            Id = id;
            CollegeId = collegeId;
            StudentNumber = studentNumber;
            ValidatedDocument = validatedDocument;
            ProofDocument = proofDocument;
            GraduationDate = graduationDate;
        }

        public Guid Id { get; private set; }

        public Guid? CollegeId { get; private set; }

        public string? StudentNumber { get; private set; }

        public bool? ValidatedDocument { get; private set; }

        public string? ProofDocument { get; private set; }

        public string? GraduationDate { get; private set; }

        public void Execute()
        {
            if(CollegeId != null)
            {
           
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(CollegeId, "CollegeId", "CollegeId cannot be null")
                );
            }

            if(StudentNumber != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(StudentNumber, "StudentNumber", "StudentNumber cannot be empty")
                );
            }

            if(ValidatedDocument != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(ValidatedDocument, "ValidatedDocument", "ValidatedDocument cannot be null")
                );
            }

            if(ProofDocument != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(ProofDocument, "ProofDocument", "ProofDocument cannot be empty")
                );
            }

            if(GraduationDate != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(GraduationDate, "GraduationDate", "GraduationDate cannot be null")
                );
            }
        }
    }
}
