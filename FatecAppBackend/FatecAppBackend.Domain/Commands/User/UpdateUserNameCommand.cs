using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.User
{
    public class UpdateUserNameCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserNameCommand(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Name, "Name", "Name cannot be empty")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
