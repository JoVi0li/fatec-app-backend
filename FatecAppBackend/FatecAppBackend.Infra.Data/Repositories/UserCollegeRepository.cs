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
    public class UserCollegeRepository : IUserCollegeRepository
    {
        private readonly FatecAppBackendContext _context;

        public UserCollegeRepository(FatecAppBackendContext context)
        {
            _context = context;
        }

        public void Create(UserCollege userCollege)
        {
            _context.UserColleges.Add(userCollege);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.UserColleges.Remove(GetById(id));
            _context.SaveChanges();
        }

        public ICollection<UserCollege> GetAll()
        {
            return _context.UserColleges.ToList();
        }

        public UserCollege? GetById(Guid id)
        {
            return _context.UserColleges.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateCollegeId(UserCollege userCollege)
        {
            _context.Entry(userCollege).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateGraduationDate(UserCollege userCollege)
        {
            _context.Entry(userCollege).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateProofDocument(UserCollege userCollege)
        {
            _context.Entry(userCollege).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateStudentNumber(UserCollege userCollege)
        {
            _context.Entry(userCollege).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateUserId(UserCollege userCollege)
        {
            _context.Entry(userCollege).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateValidatedUser(UserCollege userCollege)
        {
            _context.Entry(userCollege).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
