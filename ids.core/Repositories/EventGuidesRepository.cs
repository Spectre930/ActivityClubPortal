using ids.core.Interfaces;
using ids.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Repositories
{
    public class EventGuidesRepository : IEventGuidesRepository
    {
        private readonly ActivityClubPortalContext _dbContext;

        public EventGuidesRepository(ActivityClubPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<EventGuide> GetAllEventGuides()
        {
            return _dbContext.Set<EventGuide>().ToList();
        }

        public void AddEventGuide(EventGuide eventGuide)
        {
            _dbContext.Set<EventGuide>().Add(eventGuide);
            _dbContext.SaveChanges();
        }

        public void UpdateEventGuide(EventGuide eventGuide)
        {
            _dbContext.Entry(eventGuide).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteEventGuide(EventGuide eventGuide)
        {
            var obj = _dbContext.Set<EventGuide>().FirstOrDefault(e => e.EventId == eventGuide.EventId && e.GuideId == eventGuide.GuideId);
            if (obj != null)
            {
                _dbContext.Set<EventGuide>().Remove(eventGuide);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Guide> GetGuidesOfEvent(int EventId)
        {
            var guides = _dbContext.Set<EventGuide>()
                .Include(e => e.Guides)
                 .Where(e => e.EventId == EventId)
                 .Select(e => e.Guides)
                 .ToList();

            return guides;
        }

        public IEnumerable<Event> GetEventsOfaGuide(int GuideId)
        {
            var events = _dbContext.Set<EventGuide>()
                .Include(e => e.Events)
                .Where(e => e.GuideId == GuideId)
                .Select(e => e.Events)
                .ToList();

            return events;
        }

        public void DropGuideFromEvent(int EventId, int GuideId)
        {
            var obj = _dbContext.Set<EventGuide>().FirstOrDefault(e => e.EventId == EventId && e.GuideId == GuideId);

            if (obj != null)
            {
                _dbContext.Set<EventGuide>().Remove(obj);
                _dbContext.SaveChanges();
            }

        }

        public void AddGuideToEvent(int EventId, int GuideId)
        {
            var eg = new EventGuide
            {
                EventId = EventId,
                GuideId = GuideId,
                // Events = _dbContext.Set<Event>().FirstOrDefault(e => e.Id == EventId),
                //Guides = _dbContext.Set<Guide>().FirstOrDefault(e => e.Id == GuideId),
            };

            AddEventGuide(eg);
        }
    }
}

