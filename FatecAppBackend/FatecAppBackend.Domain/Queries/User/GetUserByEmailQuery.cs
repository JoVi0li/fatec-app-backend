using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.User
{
    public class GetUserByEmailQuery : Notifiable<Notification>, IQuery
    {
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Email, "Email", "Email cannot be empty")
                    .IsEmail(Email, "Email", "Invalid E-mail")
                    .Contains(Email, "@fatec.sp.gov.br", "Email", "Invalid Email")
            );
        }
    }
}
