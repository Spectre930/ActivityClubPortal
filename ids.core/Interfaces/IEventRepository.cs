using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int id);
        void AddEvent(Event events);
        void UpdateEvent(Event events);
        void DeleteEvent(int id);
        void SetLookup(int EventId, int lookupId);
        IEnumerable<Member> GetMembers(int EventsId);

    }
}
