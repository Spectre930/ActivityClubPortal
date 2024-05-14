using ids.core.Models;


namespace ids.core.Interfaces
{
    public interface IEventGuidesRepository
    {
        IEnumerable<EventGuide> GetAllEventGuides();
        IEnumerable<Event> GetEventsOfaGuide(int GuideId);
        IEnumerable<Guide> GetGuidesOfEvent(int EventId);
        void AddEventGuide(EventGuide eventGuide);
        void UpdateEventGuide(EventGuide eventGuide);
        void DeleteEventGuide(EventGuide eventGuide);
        void DropGuideFromEvent(int EventId, int GuideId);
        void AddGuideToEvent(int EventId, int GuideId);

    }
}
