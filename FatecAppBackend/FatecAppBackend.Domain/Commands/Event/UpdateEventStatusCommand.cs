using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Event
{
    public class UpdateEventStatusCommand : Notifiable<Notification>, ICommand
    {
        public UpdateEventStatusCommand(EnStatus status, Guid id)
        {
            Status = status;
            Id = id;
        }

        public EnStatus Status { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Status, "Status", "Status cannot be null")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
