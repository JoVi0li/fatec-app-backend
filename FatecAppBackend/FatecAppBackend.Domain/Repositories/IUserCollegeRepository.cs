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
        UserCollege? GetById(Guid id);

        /// <summary>
        /// Search an UserCollege by CollegeId
        /// </summary>
        /// <param name="collegeId"></param>
        /// <returns>An UserCollege</returns>
        UserCollege? GetByCollegeId(Guid collegeId);

        /// <summary>
        /// Search an UserCollege by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>An UserCollege</returns>
        UserCollege? GetByUserId(Guid userId);

        /// <summary>
        /// Delete an UserCollege by Id
        /// </summary>
        /// <param name="id">UserCollege Id</param>
        void Delete(Guid id);

        /// <summary>
        /// Update an UserCollege
        /// </summary>
        /// <param name="userCollege">UserCollege props</param>
        void Update(UserCollege userCollege);

    }
}
