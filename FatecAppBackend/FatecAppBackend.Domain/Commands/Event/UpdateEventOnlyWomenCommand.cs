using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Event
{
    public class UpdateEventOnlyWomenCommand : Notifiable<Notification>, ICommand
    {
        public UpdateEventOnlyWomenCommand(bool onlyWomen, Guid id)
        {
            OnlyWomen = onlyWomen;
            Id = id;
        }

        public bool OnlyWomen { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(OnlyWomen, "OnlyWomen", "OnlyWomen cannot be null")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
