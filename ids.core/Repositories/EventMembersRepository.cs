using ids.core.Interfaces;
using ids.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Repositories
{
    public class EventMembersRepository : IEventMembersRepository
    {
        private readonly ActivityClubPortalContext _dbContext;

        public EventMembersRepository(ActivityClubPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<EventsMember> GetAllEventMembers()
        {
            return _dbContext.Set<EventsMember>().ToList();
        }

        public EventsMember GetEventMemberById(int id)
        {
            return _dbContext.Set<EventsMember>().Find(id);
        }

        public void AddEventMember(EventsMember eventMember)
        {
            _dbContext.Set<EventsMember>().Add(eventMember);
            _dbContext.SaveChanges();
        }

        public void UpdateEventMember(EventsMember eventMember)
        {
            _dbContext.Entry(eventMember).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteEventMember(int id)
        {
            var eventMember = _dbContext.Set<EventsMember>().Find(id);
            if (eventMember != null)
            {
                _dbContext.Set<EventsMember>().Remove(eventMember);
                _dbContext.SaveChanges();
            }
        }

        public void JoinEvent(int EventId, int MemberId)
        {
            var obj = new EventsMember
            {
                EventsId = EventId,
                MembersId = MemberId,
                //Events = _dbContext.Set<Event>().Find(EventId),
                //Members = _dbContext.Set<Member>().Find(MemberId)
            };

            AddEventMember(obj);
        }
    }
}
