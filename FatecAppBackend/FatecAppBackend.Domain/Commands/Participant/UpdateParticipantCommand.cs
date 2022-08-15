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
    public class UpdateParticipantCommand : Notifiable<Notification>, ICommand
    {
        public UpdateParticipantCommand(Entities.Participant participant)
        {
            Participant = participant;
        }

        public Entities.Participant Participant { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Participant, "Participant", "Participant cannot be null")
            );
        }
    }
}
