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
    public class CreateUserCommand : Notifiable<Notification>, ICommand
    {
        public CreateUserCommand(string name, string email, string password, string photo, string phoneNumber, string identityDocumentNumber, string identityDocPhotoFront, string identityDocPhotoBack, EnGender gender, bool validatedUser)
        {
            Name = name;
            Email = email;
            Password = password;
            Photo = photo;
            PhoneNumber = phoneNumber;
            IdentityDocumentNumber = identityDocumentNumber;
            IdentityDocumentPhotoFront = identityDocPhotoFront;
            IdentityDocumentPhotoBack = identityDocPhotoBack;
            Gender = gender;
            ValidatedUser = validatedUser;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Photo { get; set; }

        public string PhoneNumber { get; set; }

        public string IdentityDocumentNumber { get; set; }

        public string IdentityDocumentPhotoFront { get; set; }

        public string IdentityDocumentPhotoBack { get; set; }

        public EnGender Gender { get; set; }

        public bool ValidatedUser { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Name, "Name", "Name cannot be empty")
                    .IsEmail(Email, "Email", "Invalid E-mail")
                    .Contains(Email, "@fatec.sp.gov.br", "Email", "Invalid Email")
                    .IsGreaterThan(Password, 7, "Password must be greater than 7 characters")
                    .IsNotNull(Photo, "Photo", "Photo cannot be null")
                    .IsNotNull(PhoneNumber, "PhoneNumber", "PhoneNumber cannot be null")
                    .IsNotNull(IdentityDocumentNumber, "IdentityDocumentNumber", "IdentityDocumentNumber cannot be null")
                    .IsNotEmpty(IdentityDocumentPhotoFront, "IdentityDocumentPhotoFront", "IdentityDocumentPhotoFront cannot be empty")
                    .IsNotEmpty(IdentityDocumentPhotoBack, "IdentityDocumentPhotoBack", "IdentityDocumentPhotoBack cannot be empty")
                    .IsNotNull(Gender, "Gender", "Gender cannot be null")
                    .IsNotNull(ValidatedUser, "ValidatedUser", "ValidatedUser cannot be null")
            );
        }
    }
}
