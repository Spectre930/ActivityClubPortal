using ids.core.Interfaces;
using ids.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ActivityClubPortalContext _dbContext;

        public EventRepository(ActivityClubPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _dbContext.Set<Event>().Include(e => e.Lookup).ToList();
        }

        public Event GetEventById(int id)
        {
            return _dbContext.Set<Event>().Include(e => e.Lookup).FirstOrDefault(x => x.Id == id);
        }

        public void AddEvent(Event events)
        {
            _dbContext.Set<Event>().Add(events);
            _dbContext.SaveChanges();
        }

        public void UpdateEvent(Event events)
        {
            _dbContext.Entry(events).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            var events = _dbContext.Set<Event>().Find(id);
            if (events != null)
            {
                _dbContext.Set<Event>().Remove(events);
                _dbContext.SaveChanges();
            }
        }

        public void SetLookup(int EventId, int lookupId)
        {
            var lookup = _dbContext.Set<Lookup>().Find(lookupId);
            var ev = _dbContext.Set<Event>().Find(EventId);
            if (lookup != null && ev != null)
            {
                ev.Lookup = lookup;
                ev.LookupId = lookupId;
                UpdateEvent(ev);
            }
        }

        public IEnumerable<Member> GetMembers(int EventsId)
        {
            var ev = GetEventById(EventsId);
            if (ev == null)
            {
                throw new Exception("Event not found!");
            }
            var members = _dbContext.Set<EventsMember>().Include(e => e.Members).Where(e => e.EventsId == EventsId).Select(e => e.Members).ToList();
            return members;
        }
    }
}


