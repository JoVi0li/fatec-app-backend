using FatecAppBackend.Shared.Commands;
using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.User
{
    public class UpdateUserPhoneNumberCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserPhoneNumberCommand(string phoneNumber, Guid id)
        {
            PhoneNumber = phoneNumber;
            Id = id;
        }

        public string PhoneNumber { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(PhoneNumber, "PhoneNumber", "PhoneNumber cannot be empty")
                    .IsPhoneNumber(PhoneNumber, "PhoneNumber", "Invalid PhoneNumber")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
