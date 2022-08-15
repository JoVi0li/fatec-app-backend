using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.Event
{
    public class GetEventByNameQuery : Notifiable<Notification>, IQuery
    {
        public GetEventByNameQuery(string name)
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
                    .IsGreaterThan(Name, 3, "Name", "Name must be greater than 3 characters")
            );
        }
    }
}
