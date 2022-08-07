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
        /// Delete an user with the Id
        /// </summary>
        /// <param name="id">User Id</param>
        void Delete(Guid id);

        /// <summary>
        /// Update the Email
        /// </summary>
        /// <param name="user">User with new Email</param>
        void UpdateEmail(User user);

        /// <summary>
        /// Update the Password
        /// </summary>
        /// <param name="user">User with the new Password</param>
        void UpdatePassword(User user);

        /// <summary>
        /// Update the PhoneNumber
        /// </summary>
        /// <param name="user">User with the new PhoneNumber</param>
        void UpdatePhoneNumber(User user);

        /// <summary>
        /// Update the Gender
        /// </summary>
        /// <param name="user">User with the new Gender</param>
        void UpdateGender(User user);

        /// <summary>
        /// Update the IdentityDocumentNumber
        /// </summary>
        /// <param name="user">User with the new IdentityDocumentNumber</param>
        void UpdateIdentityDocumentNumber(User user);

        /// <summary>
        /// Update the IdentityDocumentPhoto
        /// </summary>
        /// <param name="user">User with the new IdentityDocumentPhoto</param>
        void UpdateIdentityDocumentPhoto(User User);

        /// <summary>
        /// Update the Name
        /// </summary>
        /// <param name="user">User with the new Name</param>
        void UpdateName(User user);

        /// <summary>
        /// Update the Photo
        /// </summary>
        /// <param name="user">User with the new Photo</param>
        void UpdatePhoto(User user);

        /// <summary>
        /// Update the ValidatedUser
        /// </summary>
        /// <param name="user">User with the new ValidatedUser</param>
        void UpdateValidatedUser(User user);
    }
}
