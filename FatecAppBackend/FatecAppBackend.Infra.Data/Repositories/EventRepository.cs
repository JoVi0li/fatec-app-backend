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
    public class EventRepository : IEventRepository
    {
        private readonly FatecAppBackendContext _context;

        public EventRepository(FatecAppBackendContext context)
        {
            _context = context;
        }

        public void Create(Event @event)
        {
            _context.Events.Add(@event);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.Events.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IReadOnlyCollection<Event> GetAll()
        {
            return _context.Events.ToList();
        }

        public Event? GetById(Guid id)
        {
            return _context.Events.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateFrom(Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateOnlyWomen(Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateRoute(Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateStatus(Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateTimeToGo(Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateTo(Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
