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
    public class GetEventByIdQuery : Notifiable<Notification>, IQuery
    {
        public GetEventByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
