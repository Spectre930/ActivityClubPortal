using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();
        Member GetMemberById(int id);
        Member GetMemberByEmail(string email);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
        IEnumerable<Event> GetEvents(int MemberId);

    }
}
