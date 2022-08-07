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

        public void UpdateStudentNumber(string newStudentNumber)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(newStudentNumber, "StudentNumber", "StudentNumber cannot be empty")
                    .AreNotEquals(newStudentNumber, StudentNumber, "StudentNumber", "New StudentNumber cannot be equal the old StudentNumber")
            );

            if (IsValid)
            {
                StudentNumber = newStudentNumber;
            } else
            {
                AddNotification("StudentNumber", "Could not update StudentNumber");
            }
        }

        public void UpdateValidatedDocument(bool newValidatedDocument)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(newValidatedDocument, "ValidatedDocument", "ValidatedDocument cannot be null")
                    .AreNotEquals(newValidatedDocument, ValidatedDocument, "ValidatedDocument", "New ValidatedDocument cannot be equal the old ValidatedDocument")
            );

            if (IsValid)
            {
                ValidatedDocument = newValidatedDocument;
            } else
            {
                AddNotification("ValidatedDocument", "Could not update ValidatedDocument");
            }
        }

        public void UpdateProofDocument(string newProofDocument)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(newProofDocument, "ProofDocument", "ProofDocument cannot be empty")
                    .AreNotEquals(newProofDocument, ProofDocument, "ProofDocument", "New ProofDocument cannot be equal the old ProofDocument")
            );

            if (IsValid)
            {
                ProofDocument = newProofDocument;
            } else
            {
                AddNotification("ProofDocument", "Could not update ProofDocument");
            }
        }

        public void UpdateGraduationDate(DateTime newGraduationDate)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(newGraduationDate, "GraduationDate", "GraduationDate cannot be null")
                    .AreNotEquals(newGraduationDate, GraduationDate, "GraduationDate", "New GraduationDate cannot be equal the old GraduationDate")
            );

            if (IsValid)
            {
                GraduationDate = newGraduationDate;
            } else
            {
                AddNotification("GraduationDate", "Could not update GraduationDate");
            }
        }

        public void AddEvent(Event @event)
        {
            if(Events.Any(x => x.Id == @event.Id))
            {
                AddNotification("Event", "Event already exists");
            } else
            {
                if (IsValid)
                {
                    Events.Add(@event);
                } else
                {
                    AddNotification("Event", "Could not add Event");
                }
            }
        }

        public void RemoveEvent(Guid id)
        {
            Event? @event = Events.FirstOrDefault(x => x.Id == id);

            if (IsValid)
            {
                if (@event == null)
                {
                    AddNotification("Event", "Event nonexistent");
                }
                else
                {
                    Events.Remove(@event);
                }
            } else
            {
                AddNotification("Event", "Could not remove Event");
            }
        }

    }
}
