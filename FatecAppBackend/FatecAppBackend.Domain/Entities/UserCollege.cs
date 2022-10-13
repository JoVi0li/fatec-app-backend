using FatecAppBackend.Domain.Commands.UserCollege;
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
                    .IsNotEmpty(proofDoc, "ProofDocument", "ProofDocument cannot be empty")
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


        //Props

        public string StudentNumber { get; private set; }

        public bool ValidatedDocument { get; private set; }

        public string ProofDocument { get; private set; }

        public DateTime GraduationDate { get; private set; }


        // Compositions

        [ForeignKey("User")]
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        [ForeignKey("College")]
        public Guid CollegeId { get; private set; }
        public College College { get; private set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Participant> Participants { get; set; } 


        // Update

        public void Update(UpdateUserCollegeCommand updateUserCollege)
        {
            if(updateUserCollege.CollegeId != null)
            {
                if(updateUserCollege.CollegeId != CollegeId)
                {
                    CollegeId = (Guid)updateUserCollege.CollegeId;
                }
                else
                {
                    AddNotification("CollegeId", "Could not update, invalid value");
                }
            }

            if(updateUserCollege.StudentNumber != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(updateUserCollege.StudentNumber, "StudentNumber", "StudentNumber cannot be empty")
                );

                if(updateUserCollege.StudentNumber != StudentNumber)
                {
                    StudentNumber = updateUserCollege.StudentNumber;
                }
                else
                {
                    AddNotification("StudentNumber", "Could not update, invalid value");
                }
            }

            if(updateUserCollege.ValidatedDocument != null)
            {
                if(updateUserCollege.ValidatedDocument != ValidatedDocument)
                {
                    ValidatedDocument = (bool)updateUserCollege.ValidatedDocument;
                }
                else
                {
                    AddNotification("ValidatedDocument", "Could not update, invalid value");
                }
            }

            if(updateUserCollege.ProofDocument != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(updateUserCollege.ProofDocument, "ProofDocument", "ProofDocument cannot be empty")
                );

                if(updateUserCollege.ProofDocument != ProofDocument)
                {
                    ProofDocument = (string)updateUserCollege.ProofDocument;
                }
                else
                {
                    AddNotification("ProofDocument", "Could not update, invalid value");
                }
            }

            if(updateUserCollege.GraduationDate != null)
            {
                if(updateUserCollege.GraduationDate != GraduationDate.ToString())
                {
                    GraduationDate = DateTime.Parse(updateUserCollege.GraduationDate);
                }
                else
                {
                    AddNotification("ProofDocument", "Could not update, invalid value");
                }
            }
        }

    }
}
