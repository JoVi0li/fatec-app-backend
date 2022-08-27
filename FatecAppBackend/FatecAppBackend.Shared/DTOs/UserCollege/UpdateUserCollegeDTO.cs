using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Shared.DTOs.UserCollege
{
    public class UpdateUserCollegeDTO
    {
        public UpdateUserCollegeDTO(Guid id, Guid? collegeId, string? studentNumber, bool? validatedDocument, string? proofDocument, string? graduationDate)
        {
            Id = id;
            CollegeId = collegeId;
            StudentNumber = studentNumber;
            ValidatedDocument = validatedDocument;
            ProofDocument = proofDocument;
            GraduationDate = graduationDate;
        }
        public Guid Id { get; private set; }

        public Guid? CollegeId { get; private set; }

        public string? StudentNumber { get; private set; }

        public bool? ValidatedDocument { get; private set; }

        public string? ProofDocument { get; private set; }

        public string? GraduationDate { get; private set; }

    }
}
