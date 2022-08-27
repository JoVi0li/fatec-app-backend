using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.User
{
    public class GetUserByNameQuery : Notifiable<Notification>, IQuery
    {
        public GetUserByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Name, "Name", "Name cannot be empty")
                    .IsGreaterOrEqualsThan(Name, 3, "Name", "Name must be greater or equals than 3 characters")
            );
        }
    }
}
