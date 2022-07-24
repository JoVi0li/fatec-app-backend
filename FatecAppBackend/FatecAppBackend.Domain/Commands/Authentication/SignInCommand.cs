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

        public string Email { get; set; }

        public string Password { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Email, "Email", "Email cannot be empty")
                    .IsEmail(Email, "Email", "Invalid Email")
                    .Contains(Email, "@fatec.sp.gov.br", "Email", "Invalid Email")
                    .IsNotEmpty(Password, "Password", "Password cannot be empty")
                    .IsGreaterThan(Password, 7, "Password", "Invalid Password")
            );
        }
    }
}
