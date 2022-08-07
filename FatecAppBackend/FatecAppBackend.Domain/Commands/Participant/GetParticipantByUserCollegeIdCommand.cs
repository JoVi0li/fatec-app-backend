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
    public class GetParticipantByUserCollegeIdCommand : Notifiable<Notification>, ICommand
    {
        public GetParticipantByUserCollegeIdCommand(Guid userCollegeId)
        {
            UserCollegeId = userCollegeId;
        }

        public Guid UserCollegeId { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(UserCollegeId, "UserCollegeId", "UserCollegeId cannot be null")
            );
        }
    }
}
