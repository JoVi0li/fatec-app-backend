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
    public class UpdateUserPhotoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserPhotoCommand(string photo, Guid id)
        {
            Photo = photo;
            Id = id;
        }

        public string Photo { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Photo, "Photo", "Photo cannot be empty")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
