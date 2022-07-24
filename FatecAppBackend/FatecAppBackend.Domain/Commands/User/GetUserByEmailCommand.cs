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
    public class GetUserByEmailCommand : Notifiable<Notification>, ICommand
    {
        public GetUserByEmailCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsEmail(Email, "Email", "Invalid E-mail")
                    .Contains(Email, "@fatec.sp.gov.br", "Email", "Invalid Email")
            );
        }
    }
}
