using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.UserCollege
{
    public class GetUserCollegeByUserIdQuery : Notifiable<Notification>, IQuery
    {
        public GetUserCollegeByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(UserId, "UserId", "UserId cannot be null")
            );
        }
    }
}
