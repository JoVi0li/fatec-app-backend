using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Shared.DTOs.User
{
    public class UpdateUserDTO
    {
        public UpdateUserDTO(Guid id, Guid userCollegeId, string? name, string? email, string? photo, string? phoneNumber, string? identityDocumentNumber, string? identityDocumentPhoto, bool? validatedUser, EnGender? gender)
        {
            Id = id;
            UserCollegeId = userCollegeId;
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

        public Guid UserCollegeId { get; set; }

        public string? Name { get; private set; }

        public string? Email { get; private set; }

        public string? Photo { get; private set; }

        public string? PhoneNumber { get; private set; }

        public string? IdentityDocumentNumber { get; private set; }

        public string? IdentityDocumentPhoto { get; private set; }

        public EnGender? Gender { get; private set; }

        public bool? ValidatedUser { get; private set; }
    }
}
