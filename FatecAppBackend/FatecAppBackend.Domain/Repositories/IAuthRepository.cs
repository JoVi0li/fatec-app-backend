using FatecAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Repositories
{
    public interface IAuthRepository 
    {
        /// <summary>
        /// Change the User's password
        /// </summary>
        /// <param name="user">User props</param>
        void ChangePassword(User user);

    }
}
