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
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly FatecAppBackendContext _context;

        public ParticipantRepository(FatecAppBackendContext context)
        {
            _context = context;
        }

        public void Create(Participant participant)
        {
            _context.Participants.Add(participant);
            _context.SaveChanges();
        }

        public ICollection<Participant>? GetByEventId(Guid id)
        {
            return _context.Participants
                .Include(x => x.UserCollege)
                .Include(x => x.Event)
                .Where(x => x.EventId == id).ToList();
        }

        public Participant? GetById(Guid id)
        {
            return _context.Participants
                .Include(x => x.UserCollege)
                .Include(x => x.Event)
                .FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Participant>? GetByUserCollegeId(Guid id)
        {
            return _context.Participants
                .Include(x => x.UserCollege)
                .Include(x => x.Event)
                .Where(x => x.UserCollegeId == id).ToList();
        }

        public void Remove(Guid id)
        {
            _context.Participants.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void Update(Participant participant)
        {
            _context.Entry(participant).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
