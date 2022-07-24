using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.User
{
    public class UpdateUserEmailCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserEmailCommand(string email, Guid id)
        {
            Email = email;
            Id = id;
        }

        public string Email { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Email, "Email", "Email cannot be empty")
                    .IsEmail(Email, "Email", "Invalid Email")
                    .Contains(Email, "@fatec.sp.gov.br", "Email", "Invalid Email")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
