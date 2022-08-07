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
    public class RemoveParticipantCommand : Notifiable<Notification>, ICommand
    {
        public RemoveParticipantCommand(Guid participantId)
        {
            ParticipantId = participantId;
        }

        public Guid ParticipantId { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(ParticipantId, "ParticipantId", "ParticipantId cannot be null")
            );
        }
    }
}
