using FatecAppBackend.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.User
{
    public class GetUserQueryResult
    {
        public GetUserQueryResult(Guid id, Guid userCollegeId, string name, string email, string photo, string phoneNumber, string identityDocumentNumber, EnGender gender, bool validatedUser, bool validatedDoc)
        {
            Id = id;
            UserCollegeId = userCollegeId;
            Name = name;
            Email = email;
            Photo = photo;
            PhoneNumber = phoneNumber;
            IdentityDocumentNumber = identityDocumentNumber;
            Gender = gender;
            ValidatedUser = validatedUser;
            ValidatedDoc = validatedDoc;
        }

        public Guid Id { get; private set; }

        public Guid UserCollegeId { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Photo { get; private set; }

        public string PhoneNumber { get; private set; }

        public string IdentityDocumentNumber { get; private set; }

        public EnGender Gender { get; private set; }

        public bool ValidatedUser { get; private set; }

        public bool ValidatedDoc { get; private set; }
    }
}
