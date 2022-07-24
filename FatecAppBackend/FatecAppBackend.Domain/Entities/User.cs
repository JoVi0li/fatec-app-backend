using FatecAppBackend.Shared;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain
{
    public class User : Base
    {
        public User(
            string name,
            string email,
            string password,
            string photo,
            string phoneNumber,
            string identityDocNumber,
            string identityDocPhoto,
            EnGender gender,
            bool validatedUser
           )
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(name, "Name", "Name cannot be empty")
                    .IsEmail(email, "Email", "Invalid E-mail")
                    .Contains(email, "@fatec.sp.gov.br", "Email", "Invalid Email")
                    .IsGreaterThan(password, 7, "Password must be greater than 7 characters")
                    .IsNotNull(photo, "Photo", "Photo cannot be null")
                    .IsNotNull(phoneNumber, "PhoneNumber", "PhoneNumber cannot be null")
                    .IsNotNull(identityDocNumber, "IdentityDocumentNumber", "IdentityDocumentNumber cannot be null")
                    .IsNotNull(identityDocPhoto, "IdentityDocumentPhoto", "IdentityDocumentPhoto cannot be null")
                    .IsNotNull(gender, "Gender", "Gender cannot be null")
                    .IsNotNull(validatedUser, "ValidatedUser", "ValidatedUser cannot be null")
            );

            if (IsValid)
            {
                Name = name;
                Email = email;
                Password = password;
                Photo = photo;
                PhoneNumber = phoneNumber;
                IdentityDocumentNumber = identityDocNumber;
                IdentityDocumentPhoto = identityDocPhoto;
                Gender = gender;
                ValidatedUser = validatedUser;
            }
            else
            {
                throw new Exception("Invalid User props");
            }

        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Photo { get; private set; }

        public string PhoneNumber { get; private set; }

        public string IdentityDocumentNumber { get; private set; }

        public string IdentityDocumentPhoto { get; private set; }

        public EnGender Gender { get; private set; }

        public bool ValidatedUser { get; private set; }

        public UserCollege UserCollege { get; set; }


        //Updates

        public void UpdateName(string newName)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(newName, "Name", "Name cannot be empty")
                    .AreNotEquals(newName, Name, "Name", "New Name cannot be equal the old name")
            );

            if (IsValid)
            {
                Name = newName;
            }
            else
            {
                throw new Exception("Could not update Name");
            }
        }

        public void UpdateEmail(string newEmail)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsEmail(newEmail, "Email", "Email cannot be null")
                    .Contains(newEmail, "@fatec.sp.gov.br", "Email", "Invalid Email")
                    .AreNotEquals(newEmail, Email, "Email", "New Email number cannot be equal the old Email")
            );

            if (IsValid)
            {
                Email = newEmail;
            }
            else
            {
                throw new Exception("Could not update Email");
            }
        }

        public void UpdatePassword(string newPassword)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsGreaterThan(newPassword, 7, "Password", "Password must be greater than 7 characters")
                    .AreNotEquals(newPassword, Password, "Password", "New Password cannot be equal the old password")
            );

            if (IsValid)
            {
                Password = newPassword;
            }
            else
            {
                throw new Exception("Could not update Password");
            }
        }

        public void UpdatePhoto(string newPhoto)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(newPhoto, "Photo", "Photo cannot be null")
                    .AreNotEquals(newPhoto, Photo, "New Photo cannot be equal the old photo")
            );

            if (IsValid)
            {
                Photo = newPhoto;
            }
            else
            {
                throw new Exception("Could not update Photo");
            }
        }

        public void UpdatePhoneNumber(string newPhoneNumber)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(newPhoneNumber, "PhoneNumber", "PhoneNumber cannot be empty")
                    .AreNotEquals(newPhoneNumber, PhoneNumber, "PhoneNumber", "New PhoneNumber cannot be equal the old PhoneNumber")
            );

            if (IsValid)
            {
                PhoneNumber = newPhoneNumber;
            } else
            {
                throw new Exception("Could not update PhoneNumber");
            }
        }

        public void UpdateValidatedUser(bool newValidatedUser)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(newValidatedUser, "ValidatedUser", "ValidatedUser cannot be null")
                    .AreNotEquals(newValidatedUser, ValidatedUser, "ValidatedUser", "New ValidatedUser number cannot be equal the old ValidatedUser")
            );

            if (IsValid)
            {
                ValidatedUser = newValidatedUser;
            } else
            {
                throw new Exception("Could not update ValidatedUser");
            }
        }

    }
}
