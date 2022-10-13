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
    public class CreateUserCollegeCommand : Notifiable<Notification>, ICommand
    {
        public CreateUserCollegeCommand(Guid userId, Guid collegeId, string studentNumber, bool validatedDocument, string proofDocument, string graduationDate)
        {
            UserId = userId;
            CollegeId = collegeId;
            StudentNumber = studentNumber;
            ValidatedDocument = validatedDocument;
            ProofDocument = proofDocument;
            GraduationDate = graduationDate;
        }

        public Guid UserId { get; set; }

        public Guid CollegeId { get; private set; }

        public string StudentNumber { get; private set; }

        public bool ValidatedDocument { get; private set; }

        public string ProofDocument { get; set; }

        public string GraduationDate { get; private set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(UserId, "UserId", "UserId cannot be null")
                    .IsNotNull(CollegeId, "CollegeId", "CollegeId cannnot be null")
                    .IsNotEmpty(StudentNumber, "StudentNumber", "StudentNumber cannot be empty")
                    .IsNotNull(ValidatedDocument, "ValidatedDocument", "ValidatedDocument cannot be null")
                    .IsNotNull(ProofDocument, "ProofDocument", "ProofDocument cannot be null")
                    .IsNotEmpty(GraduationDate, "GraduationDate", "GraduationDate cannot be empty")
            );
        }
    }
}
