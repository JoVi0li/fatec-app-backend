using FatecAppBackend.Shared;
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
    public class UpdateUserGenderCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserGenderCommand(EnGender gender, Guid id)
        {
            Gender = gender;
            Id = id;
        }

        public EnGender Gender { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Gender, "Gender", "Gender cannot be null")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
