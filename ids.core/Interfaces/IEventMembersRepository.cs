using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Interfaces
{
    public interface IEventMembersRepository
    {
        IEnumerable<EventsMember> GetAllEventMembers();
        void AddEventMember(EventsMember eventMember);
        void UpdateEventMember(EventsMember eventMember);
        void DeleteEventMember(int id);
        void JoinEvent(int EventId, int MemberId);
    }
}
