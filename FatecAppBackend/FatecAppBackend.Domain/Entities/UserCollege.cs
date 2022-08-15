using FatecAppBackend.Domain.Entities;
using FatecAppBackend.Shared;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Entities
{
    public class UserCollege : Base
    {
        public UserCollege()
        {

        }

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
                AddNotification("UserCollege", "Invalid UserCollege props");
            }
        }

        [ForeignKey("User")]
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        [ForeignKey("College")]
        public Guid CollegeId { get; private set; }
        public College College { get; private set; }

        public string StudentNumber { get; private set; }

        public bool ValidatedDocument { get; private set; }

        public string ProofDocument { get; private set; }

        public DateTime GraduationDate { get; private set; }

        public ICollection<Event> Events { get; set; }
        
        public virtual ICollection<Participant> Participants { get; set; } 

        // Updates

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="collegeId">New CollegeId</param>
        /// <param name="studentNumber">New StudentNumber</param>
        /// <param name="proofDoc">New ProofDocument</param>
        /// <param name="graduationDate">New GraduationDate</param>
        public void Update(Guid collegeId, string studentNumber, string proofDoc, DateTime graduationDate)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(collegeId, "CollegeId", "CollegeId cannnot be null")
                    .IsNotEmpty(studentNumber, "StudentNumber", "StudentNumber cannot be empty")
                    .IsNotNull(proofDoc, "ProofDocument", "ProofDocument cannot be null")
                    .IsNotNull(graduationDate, "GraduationDate", "GraduationDate cannot be null")
            );

            if (IsValid)
            {
                CollegeId = collegeId;
                StudentNumber = studentNumber;
                ProofDocument = proofDoc;
                GraduationDate = graduationDate;
            }
            else
            {
                AddNotification("UserCollege", "Invalid UserCollege props");
            }
        }

    }
}
