using ids.core.Interfaces;
using ids.core.Models;
using ids.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.services
{
    public class EventGuidesService : IEventGuidesService
    {
        private readonly IEventGuidesRepository _eventGuidesRepository;

        public EventGuidesService(IEventGuidesRepository eventGuidesRepository)
        {
            _eventGuidesRepository = eventGuidesRepository;
        }

        public IEnumerable<EventGuide> GetAllEventGuides()
        {
            return _eventGuidesRepository.GetAllEventGuides();
        }



        public void AddEventGuides(EventGuide eventGuide)
        {
            if (ValidateProduct(eventGuide))
            {
                _eventGuidesRepository.AddEventGuide(eventGuide);
            }
            else
            {
                throw new ArgumentException("Invalid product data");
            }
        }

        public void UpdateEventGuides(EventGuide eventGuide)
        {
            if (ValidateProduct(eventGuide))
            {
                _eventGuidesRepository.UpdateEventGuide(eventGuide);
            }
            else
            {
                throw new ArgumentException("Invalid eventguide data");
            }
        }

        public void DeleteEventGuides(EventGuide eventGuide)
        {
            _eventGuidesRepository.DeleteEventGuide(eventGuide);
        }
        private bool ValidateProduct(EventGuide eventGuide)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the price is valid

            if (string.IsNullOrWhiteSpace(eventGuide.Events.Name))
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Guide> GetGuidesOfEvent(int EventId)
        {
            return _eventGuidesRepository.GetGuidesOfEvent(EventId);
        }

        public IEnumerable<Event> GetEventsOfaGuide(int GuideId)
        {
            return _eventGuidesRepository.GetEventsOfaGuide(GuideId);
        }

        public void DropGuideFromEvent(int EventId, int GuideId)
        {
            _eventGuidesRepository.DropGuideFromEvent(EventId, GuideId);
        }

        public void AddGuideToEvent(int EventId, int GuideId)
        {
            _eventGuidesRepository.AddGuideToEvent(EventId, GuideId);
        }
    }
}
