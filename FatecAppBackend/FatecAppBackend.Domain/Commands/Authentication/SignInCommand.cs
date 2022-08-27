using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.Authentication
{
    public class SignInCommand : Notifiable<Notification>, ICommand
    {
        public SignInCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsEmail(Email, "Email", "Invalid E-mail")
                    .Contains(Email, "@fatec.sp.gov.br", "Email", "Invalid Email")
                    .IsGreaterThan(Password, 7, "Password must be greater than 7 characters")
            );
        }
    }
}
