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
    public class CollegeRepository : ICollegeRepository
    {
        private readonly FatecAppBackendContext _context;

        public CollegeRepository(FatecAppBackendContext context)
        {
            _context = context;
        }

        public void Create(College college)
        {
            _context.Colleges.Add(college);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.Colleges.Remove(GetById(id));
            _context.SaveChanges(); 
        }

        public ICollection<College> GetAll()
        {
            return _context.Colleges.ToList();
        }

        public College? GetById(Guid id)
        {
            return _context.Colleges.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<College>? GetByName(string name)
        {
            return _context.Colleges.Where(x => x.Name == name).ToList();
        }

        public void Update(College college)
        {
            _context.Entry(college).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
