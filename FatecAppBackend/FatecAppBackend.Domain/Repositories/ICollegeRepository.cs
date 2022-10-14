using FatecAppBackend.Domain.Entities;
using FatecAppBackend.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Repositories
{
    public interface ICollegeRepository
    {
        /// <summary>
        /// Create a new College
        /// </summary>
        /// <param name="college">College props</param>
        void Create(College college);

        /// <summary>
        /// Get a list of all Colleges
        /// </summary>
        /// <returns>A list of Colleges</returns>
        ICollection<College> GetAll();

        /// <summary>
        /// Search a College by Id
        /// </summary>
        /// <param name="id">College Id</param>
        /// <returns>A College</returns>
        College? GetById(Guid id);

        /// <summary>
        /// Search a College by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A list of Colleges</returns>
        ICollection<College>? GetByName(string name);

        /// <summary>
        /// Delete a College with the Id
        /// </summary>
        /// <param name="id">College Id</param>
        void Delete(Guid id);

        /// <summary>
        /// Update a College
        /// </summary>
        /// <param name="college">College props</param>
        void Update(College college);
    }
}
