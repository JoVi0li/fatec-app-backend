using FatecAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Create a new User
        /// </summary>
        /// <param name="user">User props</param>
        void Create(User user);

        /// <summary>
        /// Get list of all Users
        /// </summary>
        /// <returns>A list of Users</returns>
        ICollection<User> GetAll();

        /// <summary>
        /// Search an User by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>A User</returns>
        User? GetById(Guid id);

        /// <summary>
        /// Search an User by Email
        /// </summary>
        /// <param name="email">User Email</param>
        /// <returns>An User</returns>
        User? GetByEmail(string email);

        /// <summary>
        /// Get list of Users with the name
        /// </summary>
        /// <param name="name">YUser name</param>
        /// <returns></returns>
        ICollection<User> GetByName(string name);

        /// <summary>
        /// Delete an user with the Id
        /// </summary>
        /// <param name="id">User Id</param>
        void Delete(Guid id);

        /// <summary>
        /// Update an User
        /// </summary>
        /// <param name="user">User props</param>
        void Update(User user);

    }
}
