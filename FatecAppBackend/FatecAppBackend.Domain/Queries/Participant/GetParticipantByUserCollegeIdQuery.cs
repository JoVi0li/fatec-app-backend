using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.Participant
{
    public class GetParticipantByUserCollegeIdQuery : Notifiable<Notification> , IQuery
    {
        public GetParticipantByUserCollegeIdQuery(Guid userCollegeId)
        {
            UserCollegeId = userCollegeId;
        }

        public Guid UserCollegeId { get; private set; }

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
