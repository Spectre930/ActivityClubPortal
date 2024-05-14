using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.services.Interfaces
{
    public interface IEventMembersService
    {
        IEnumerable<EventsMember> GetAllEventMembers();
        void AddEventMembers(EventsMember eventMember);
        void UpdateEventMember(EventsMember eventMember);
        void DeleteEventMember(int id);
        void JoinEvent(int EventId, int MemberId);
    }
}
