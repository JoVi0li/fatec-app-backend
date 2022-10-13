using FatecAppBackend.Shared;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Extensions.Br.Validations;
using FatecAppBackend.Domain.Commands.User;

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
            string identityDocPhotoFront,
            string identityDocPhotoBack,
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
                    .IsNotEmpty(identityDocPhotoFront, "IdentityDocumentPhotoFront", "IdentityDocumentPhotoFront cannot be empty")
                    .IsNotEmpty(identityDocPhotoBack, "IdentityDocumentPhotoBack", "IdentityDocumentPhotoBack cannot be empty")
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
                IdentityDocumentPhotoFront = identityDocPhotoFront;
                IdentityDocumentPhotoBack = identityDocPhotoBack;
                Gender = gender;
                ValidatedUser = validatedUser;
            }
            else
            {
                AddNotification("User", "Invalid User props");
            }

        }

        
        // Props

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Photo { get; private set; }

        public string PhoneNumber { get; private set; }

        public string IdentityDocumentNumber { get; private set; }

        public string IdentityDocumentPhotoFront { get; private set; }

        public string IdentityDocumentPhotoBack { get; private set; }

        public EnGender Gender { get; private set; }

        public bool ValidatedUser { get; private set; }


        // Composition

        public virtual UserCollege UserCollege { get; private set; }


        // Updates

        public void Update(UpdateUserCommand updateUser)
        {
            if(updateUser.Name != null)
            {
                if (updateUser.Name.Length > 3 && updateUser.Name != Name)
                {
                    Name = updateUser.Name;
                }
                else
                {
                    AddNotification("Name", "Cold not update Name, invalid prop");
                }
            }

            if(updateUser.Email != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsEmail(updateUser.Email, "Email", "Invalid E-mail")
                        .Contains(updateUser.Email, "@fatec.sp.gov.br", "Email", "Invalid Email")
                );

                if (IsValid)
                {
                    Email = updateUser.Email;
                }
                else
                {
                    AddNotification("Email", "Could not update, invalid value");

                }
            }

            if (updateUser.Photo != null )
            {
                if (updateUser.Photo.Length > 0 && updateUser.Photo != Photo)
                {
                    Photo = updateUser.Photo;
                }
                else
                {
                    AddNotification("Photo", "Could not update, invalid value");
                }
            }

            if (updateUser.PhoneNumber != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(updateUser.PhoneNumber, "PhoneNumber", "PhoneNumber cannot be null")
                        .IsPhoneNumber(updateUser.PhoneNumber, "PhoneNumber", "Invalid PhoneNumber")
                );

                if(IsValid)
                {
                    PhoneNumber = updateUser.PhoneNumber;
                }
                else
                {
                    AddNotification("PhoneNumber", "Could not update, invalid value");
                }
            }

            if(updateUser.IdentityDocumentNumber != null)
            {
                AddNotifications(
                    new Contract<Notification>()
                        .Requires()
                        .IsNotNull(updateUser.IdentityDocumentNumber, "IdentityDocumentNumber", "IdentityDocumentNumber cannot be null")
                        .IsCpf(updateUser.IdentityDocumentNumber, "IdentityDocumentNumber", "Invalid IdentityDocumentNumber")
                );

                if (IsValid)
                {
                    IdentityDocumentNumber = updateUser.IdentityDocumentNumber;
                }
                else
                {
                    AddNotification("IdentityDocumentNumber", "Could not update, invalid value");
                }
            }

            if (updateUser.IdentityDocumentPhotoFront != null)
            {
                if (updateUser.IdentityDocumentPhotoFront.Length > 0 && updateUser.IdentityDocumentPhotoFront != IdentityDocumentPhotoFront)
                {
                    IdentityDocumentPhotoFront = updateUser.IdentityDocumentPhotoFront;
                }
                else
                {
                    AddNotification("IdentityDocumentPhotoFront", "Could not update, invalid value");
                }
            }

            if (updateUser.IdentityDocumentPhotoBack != null)
            {
                if (updateUser.IdentityDocumentPhotoBack.Length > 0 && updateUser.IdentityDocumentPhotoBack != IdentityDocumentPhotoBack)
                {
                    IdentityDocumentPhotoBack = updateUser.IdentityDocumentPhotoBack;
                }
                else
                {
                    AddNotification("IdentityDocumentPhotoBack", "Could not update, invalid value");
                }
            }

            if (updateUser.ValidatedUser != null)
            {
                if(updateUser.ValidatedUser != ValidatedUser)
                {
                    ValidatedUser = (bool)updateUser.ValidatedUser;
                }
                else
                {
                    AddNotification("ValidatedUser", "Could not update, invalid value");
                }
            }

            if(updateUser.Gender != null)
            {
                if(updateUser.Gender != Gender)
                {
                    Gender = (EnGender)updateUser.Gender;
                }
                else
                {
                    AddNotification("Gender", "Could not update, invalid value");
                }
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
