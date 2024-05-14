using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.services.Interfaces
{
    public interface IEventGuidesService
    {
        IEnumerable<EventGuide> GetAllEventGuides();
        void AddEventGuides(EventGuide eventGuide);
        void UpdateEventGuides(EventGuide eventGuide);
        void DeleteEventGuides(EventGuide eventGuide);
        IEnumerable<Guide> GetGuidesOfEvent(int EventId);
        IEnumerable<Event> GetEventsOfaGuide(int GuideId);
        void DropGuideFromEvent(int EventId, int GuideId);
        void AddGuideToEvent(int EventId, int GuideId);
    }
}
