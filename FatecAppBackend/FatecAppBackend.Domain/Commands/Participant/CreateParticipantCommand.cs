using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Participant
{
    public class CreateParticipantCommand : Notifiable<Notification>, ICommand
    {
        public CreateParticipantCommand(Guid eventId, Guid userCollegeId)
        {
            EventId = eventId;
            UserCollegeId = userCollegeId;
        }

        public Guid EventId { get; set; }

        public Guid UserCollegeId { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(EventId, "EventId", "EventId cannot be null")
                    .IsNotNull(UserCollegeId, "UserCollegeId", "UserCollegeId cannot be null")
            );
        }
    }
}
