using FatecAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Repositories
{
    public interface IUserCollegeRepository
    {
        /// <summary>
        /// Create a new UserCollege
        /// </summary>
        /// <param name="userCollege">UserCollege props</param>
        void Create(UserCollege userCollege);

        /// <summary>
        /// Get a list of all UserColleges
        /// </summary>
        /// <returns>A list of UserColleges</returns>
        ICollection<UserCollege> GetAll();

        /// <summary>
        /// Search an UserCollege by Id
        /// </summary>
        /// <param name="id">UserCollege Id</param>
        /// <returns>An UserCollege</returns>
        UserCollege GetById(Guid id);

        /// <summary>
        /// Delete an UserCollege by Id
        /// </summary>
        /// <param name="id">UserCollege Id</param>
        void Delete(Guid id);

        /// <summary>
        /// Update the CollegeId
        /// </summary>
        /// <param name="id">New CollegeId</param>
        void UpdateCollegeId(Guid id);

        /// <summary>
        /// Update the UserId
        /// </summary>
        /// <param name="id">New UserId</param>
        void UpdateUserId(Guid id);

        /// <summary>
        /// Update the GraduationDate
        /// </summary>
        /// <param name="userCollege">UserCollege with the new GraduationDate</param>
        void UpdateGraduationDate(UserCollege userCollege);

        /// <summary>
        /// Update the ProofDocument
        /// </summary>
        /// <param name="userCollege">UserCollege with the new ProofDocument</param>
        void UpdateProofDocument(UserCollege userCollege);

        /// <summary>
        /// Update the StudentNumber
        /// </summary>
        /// <param name="userCollege">UserCollege with the new StudentNumber</param>
        void UpdateStudentNumber(UserCollege userCollege);

        /// <summary>
        /// Update the ValidatedUser
        /// </summary>
        /// <param name="userCollege">UserCollege with the new ValidatedUser</param>
        void UpdateValidatedUser(UserCollege userCollege);
    }
}
