using FatecAppBackend.Shared;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Extensions.Br.Validations;

namespace FatecAppBackend.Domain.Entities
{
    public class User : Base
    {
        public User()
        {

        }

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
                    .IsPhoneNumber(phoneNumber, "PhoneNumber", "Invalid PhoneNumber")
                    .IsNotNull(identityDocNumber, "IdentityDocumentNumber", "IdentityDocumentNumber cannot be null")
                    .IsCpf(identityDocNumber, "IdentityDocumentNumber", "Invalid IdentityDocumentNumber")
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
                AddNotification("User", "Invalid User props");
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



        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="name">New </param>
        /// <param name="email">New Email</param>
        /// <param name="password">New Password</param>
        /// <param name="photo">New Photo</param>
        /// <param name="phoneNumber">New PhoneNumber</param>
        /// <param name="identityDocumentNumber">New IdentityDocumentNumber</param>
        /// <param name="identityDocumentPhoto">New IdentityDocumentPhoto</param>
        /// <param name="validatedUser">New ValidatedUser</param>
        /// <param name="gender">New Gender</param>
        public void Update(string? name, string? email, string? photo, string? phoneNumber, string? identityDocumentNumber, string? identityDocumentPhoto, bool? validatedUser, EnGender? gender)
        {
            if(name != null && name.Length > 3 && name != Name)
            {
                Name = name;
            } else
            {
                AddNotification("Name", "Cold not update Name, invalid prop");
            }

            if(email != null && email.Length > 0 && email != Email)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsEmail(email, "Email", "Invalid E-mail")
                        .Contains(email, "@fatec.sp.gov.br", "Email", "Invalid Email")
                );

                if (IsValid)
                {
                    Email = email;
                }
                else
                {
                    AddNotification("Email", "Could not update, invalid value");

                }
            }
            else
            {
                AddNotification("Email", "Could not update, invalid value");
            }

            if (photo != null && photo.Length > 0 && photo != Photo)
            {
                Photo = photo;
            }
            else
            {
                AddNotification("Photo", "Could not update, invalid value");
            }

            if (phoneNumber != null && phoneNumber.Length > 9 && phoneNumber != PhoneNumber)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(phoneNumber, "PhoneNumber", "PhoneNumber cannot be null")
                        .IsPhoneNumber(phoneNumber, "PhoneNumber", "Invalid PhoneNumber")
                );

                if(IsValid)
                {
                    PhoneNumber = phoneNumber;
                }
                else
                {
                    AddNotification("PhoneNumber", "Could not update, invalid value");
                }
            }
            else
            {
                AddNotification("PhoneNumber", "Could not update, invalid value");
            }

            if(identityDocumentNumber != null && identityDocumentNumber.Length > 11 && identityDocumentNumber != IdentityDocumentNumber)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(identityDocumentNumber, "IdentityDocumentNumber", "IdentityDocumentNumber cannot be null")
                        .IsCpf(identityDocumentNumber, "IdentityDocumentNumber", "Invalid IdentityDocumentNumber")
                );

                if (IsValid)
                {
                    IdentityDocumentNumber = identityDocumentNumber;
                }
                else
                {
                    AddNotification("IdentityDocumentNumber", "Could not update, invalid value");
                }
            }

            if (identityDocumentPhoto != null && identityDocumentPhoto.Length > 0 && identityDocumentNumber != IdentityDocumentPhoto)
            {
                IdentityDocumentPhoto = identityDocumentPhoto;
            }
            else
            {
                AddNotification("IdentityDocumentPhoto", "Could not update, invalid value");
            }

            if(validatedUser != null && validatedUser != ValidatedUser)
            {
                ValidatedUser = (bool)validatedUser;
            }else
            {
                AddNotification("ValidatedUser", "Could not update, invalid value");
            }

            if(gender != null && gender != Gender)
            {
                Gender = (EnGender)gender;
            }
            else
            {
                AddNotification("Gender", "Could not update, invalid value");
            }
        }


        public void UpdatePassword(string password)
        {
            if (password != null && password.Length > 7 && password != Password)
            {
                Password = password;
            }
            else
            {
                AddNotification("Password", "Could not update, invalid value");
            }
        }
    }
}
