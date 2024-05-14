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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public Event GetEventById(int id)
        {
            return _eventRepository.GetEventById(id);
        }

        public void AddEvent(Event events)
        {
            if (ValidateProduct(events))
            {
                _eventRepository.AddEvent(events);
            }
            else
            {
                throw new ArgumentException("Invalid product data");
            }
        }

        public void UpdateEvent(Event events)
        {
            if (ValidateProduct(events))
            {
                _eventRepository.UpdateEvent(events);
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void DeleteEvent(int id)
        {
            _eventRepository.DeleteEvent(id);
        }
        private bool ValidateProduct(Event events)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the price is valid

            if (string.IsNullOrWhiteSpace(events.Name))
            {
                return false;
            }

            return true;
        }

        public void SetLookup(int EventId, int lookupId)
        {
            _eventRepository.SetLookup(EventId, lookupId);
        }

        public IEnumerable<Member> GetMembers(int EventsId)
        {
            return _eventRepository.GetMembers(EventsId);
        }
    }
}
