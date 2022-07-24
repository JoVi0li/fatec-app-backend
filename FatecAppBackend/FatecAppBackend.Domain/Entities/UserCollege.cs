using FatecAppBackend.Shared;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain
{
    public class UserCollege : Base
    {
        public UserCollege(
            Guid userId,
            Guid collegeId,
            string studentNumber,
            bool validatedDoc,
            string proofDoc,
            DateTime graduationDate
        )
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(userId, "UserId", "UserId cannot be null")
                    .IsNotNull(collegeId, "CollegeId", "CollegeId cannnot be null")
                    .IsNotEmpty(studentNumber, "StudentNumber", "StudentNumber cannot be empty")
                    .IsNotNull(validatedDoc, "ValidatedDocument", "ValidatedDocument cannot be null")
                    .IsNotNull(proofDoc, "ProofDocument", "ProofDocument cannot be null")
                    .IsNotNull(graduationDate, "GraduationDate", "GraduationDate cannot be null")
            );

            if (IsValid)
            {
                UserId = userId;
                CollegeId = collegeId;
                StudentNumber = studentNumber;
                ValidatedDocument = validatedDoc;
                ProofDocument = proofDoc;
                GraduationDate = graduationDate;
            } else
            {
                throw new Exception("Invalid UserCollege props");
            }
        }

        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Guid CollegeId { get; private set; }
        public College College { get; private set; }

        public string StudentNumber { get; private set; }

        public bool ValidatedDocument { get; private set; }

        public string ProofDocument { get; private set; }

        public DateTime GraduationDate { get; private set; }
    }
}
