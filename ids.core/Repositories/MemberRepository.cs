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
    public class MemberRepository : IMemberRepository
    {
        private readonly ActivityClubPortalContext _dbContext;

        public MemberRepository(ActivityClubPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _dbContext.Set<Member>().ToList();
        }

        public Member GetMemberById(int id)
        {
            return _dbContext.Set<Member>().Find(id);
        }

        public void AddMember(Member member)
        {
            _dbContext.Set<Member>().Add(member);
            _dbContext.SaveChanges();
        }

        public void UpdateMember(Member member)
        {
            _dbContext.Entry(member).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteMember(int id)
        {
            var member = _dbContext.Set<Member>().Find(id);
            if (member != null)
            {
                _dbContext.Set<Member>().Remove(member);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Event> GetEvents(int MemberId)
        {
            var member = GetMemberById(MemberId);
            if (member == null)
            {
                throw new Exception("member not found!");
            }
            var events = _dbContext.Set<EventsMember>().Include(e => e.Events).Where(e => e.MembersId == MemberId).Select(e => e.Events).ToList();
            return events;
        }

        public Member GetMemberByEmail(string email)
        {
            return _dbContext.Set<Member>().FirstOrDefault(x => x.Email == email);
        }
    }
}
