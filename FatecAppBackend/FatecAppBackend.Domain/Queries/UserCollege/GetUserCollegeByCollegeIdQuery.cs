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
    public class GetUserCollegeByCollegeIdQuery : Notifiable<Notification>, IQuery
    {
        public GetUserCollegeByCollegeIdQuery(Guid collegeId)
        {
            CollegeId = collegeId;
        }

        public Guid CollegeId { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(CollegeId, "CollegeId", "CollegeId cannot be null")
            );
        }
    }
}
