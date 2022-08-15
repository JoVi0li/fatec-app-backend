using FatecAppBackend.Domain.Entities;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Infra.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FatecAppBackendContext _context;

        public AuthRepository(FatecAppBackendContext context)
        {
            _context = context;
        }

        public void ChangePassword(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
