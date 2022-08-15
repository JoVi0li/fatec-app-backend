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
    public class UserRepository : IUserRepository
    {
        private readonly FatecAppBackendContext _context;

        public UserRepository(FatecAppBackendContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.Users.Remove(GetById(id));
            _context.SaveChanges();
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User? GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<User> GetByName(string name)
        {
            return _context.Users.Where(x => x.Name == name).ToList();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
