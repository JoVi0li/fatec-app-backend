using FatecAppBackend.Shared;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.DTOs.User;
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
    public class UpdateUserCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserCommand(UpdateUserDTO updateUser)
        {
            UpdateUser = updateUser;
        }

        public UpdateUserDTO UpdateUser { get; set; }

        public void Execute()
        {
            if(UpdateUser.Email != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsEmail(UpdateUser.Email, "Email", "Invalid E-mail")
                        .Contains(UpdateUser.Email, "@fatec.sp.gov.br", "Email", "Invalid Email")
                );
            }

            if(UpdateUser.Name != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(UpdateUser.Name, "Name", "Name cannot be empty")
                        .IsGreaterThan(UpdateUser.Name, 3, "Name", "Name must be greater than 3 characters")
                );
            }

            if(UpdateUser.Photo != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(UpdateUser.Photo, "Photo", "Photo cannot be empty")
                );
            }

            if(UpdateUser.PhoneNumber != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(UpdateUser.PhoneNumber, "PhoneNumber", "PhoneNumber cannot be empty")
                        .IsPhoneNumber(UpdateUser.PhoneNumber, "PhoneNumber", "Invalid PhoneNumber")

                );
            }

            if(UpdateUser.IdentityDocumentNumber != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(UpdateUser.IdentityDocumentNumber, "IdentityDocumentNumber", "IdentityDocumentNumber cannot be empty")
                        .IsCpf(UpdateUser.IdentityDocumentNumber, "IdentityDocumentNumber", "Invalid IdentityDocumentNumber")
                );
            }

            if(UpdateUser.IdentityDocumentPhotoFront != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(UpdateUser.IdentityDocumentPhotoFront, "IdentityDocumentPhotoFront", "IdentityDocumentPhotoFront cannot be empty")
                );
            }

            if (UpdateUser.IdentityDocumentPhotoBack != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(UpdateUser.IdentityDocumentPhotoBack, "IdentityDocumentPhotoBack", "IdentityDocumentPhotoBack cannot be empty")
                );
            }

            if (UpdateUser.Gender != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                );
            }

            if (UpdateUser.ValidatedUser != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                );
            }
        }
    }
}
