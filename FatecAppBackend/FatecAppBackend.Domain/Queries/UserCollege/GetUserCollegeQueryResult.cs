using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.UserCollege
{
    public class GetUserCollegeQueryResult
    {
        public GetUserCollegeQueryResult(Guid id, Guid userId, Guid collegeId, string studentNumber, bool validatedDocument, string proofDocument, DateTime graduationDate)
        {
            Id = id;
            UserId = userId;
            CollegeId = collegeId;
            StudentNumber = studentNumber;
            ValidatedDocument = validatedDocument;
            ProofDocument = proofDocument;
            GraduationDate = graduationDate;
        }

        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public Guid CollegeId { get; private set; }

        public string StudentNumber { get; private set; }

        public bool ValidatedDocument { get; private set; }

        public string ProofDocument { get; private set; }

        public DateTime GraduationDate { get; private set; }
    }
}
