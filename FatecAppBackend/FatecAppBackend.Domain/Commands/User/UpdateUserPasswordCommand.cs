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
    public class UpdateUserPasswordCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserPasswordCommand(string password, Guid id)
        {
            Password = password;
            Id = id;
        }

        public string Password { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Password, "Password", "Password cannot be empty")
                    .IsGreaterThan(Password, 7, "Password", "Password must be greater than 7 characters")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
