using FatecAppBackend.Shared;
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
    public class UpdateUserCommand : Notifiable<Notification>, ICommand
    {
        public UpdateUserCommand(Guid id, string? name, string? email, string? photo, string? phoneNumber, string? identityDocumentNumber, string? identityDocumentPhoto, bool? validatedUser, EnGender? gender)
        {
            Id = id;
            Name = name;
            Email = email;
            Photo = photo;
            PhoneNumber = phoneNumber;
            IdentityDocumentNumber = identityDocumentNumber;
            IdentityDocumentPhoto = identityDocumentPhoto;
            Gender = gender;
            ValidatedUser = validatedUser;
        }

        public Guid Id { get; private set; }

        public string? Name { get; private set; }

        public string? Email { get; private set; }

        public string? Photo { get; private set; }

        public string? PhoneNumber { get; private set; }

        public string? IdentityDocumentNumber { get; private set; }

        public string? IdentityDocumentPhoto { get; private set; }

        public EnGender? Gender { get; private set; }

        public bool? ValidatedUser { get; private set; }

        public void Execute()
        {
            if(Email != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsEmail(Email, "Email", "Invalid E-mail")
                        .Contains(Email, "@fatec.sp.gov.br", "Email", "Invalid Email")
                );
            }

            if(Name != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(Name, "Name", "Name cannot be empty")
                        .IsGreaterThan(Name, 3, "Name", "Name must be greater than 3 characters")
                );
            }

            if(Photo != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(Photo, "Photo", "Photo cannot be empty")
                );
            }

            if(PhoneNumber != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(PhoneNumber, "PhoneNumber", "PhoneNumber cannot be empty")
                        .IsPhoneNumber(PhoneNumber, "PhoneNumber", "Invalid PhoneNumber")

                );
            }

            if(IdentityDocumentNumber != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(IdentityDocumentNumber, "IdentityDocumentNumber", "IdentityDocumentNumber cannot be empty")
                        .IsCpf(IdentityDocumentNumber, "IdentityDocumentNumber", "Invalid IdentityDocumentNumber")
                );
            }

            if(IdentityDocumentPhoto != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotEmpty(IdentityDocumentPhoto, "IdentityDocumentPhoto", "IdentityDocumentPhoto cannot be empty")
                );
            }

            if(Gender != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                );
            }

            if (ValidatedUser != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                );
            }
        }
    }
}
