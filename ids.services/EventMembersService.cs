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
    public class EventMembersService : IEventMembersService
    {
        private readonly IEventMembersRepository _eventMembersRepository;

        public EventMembersService(IEventMembersRepository eventMembersRepository)
        {
            _eventMembersRepository = eventMembersRepository;
        }

        public IEnumerable<EventsMember> GetAllEventMembers()
        {
            return _eventMembersRepository.GetAllEventMembers();
        }

        public void AddEventMembers(EventsMember eventMember)
        {
            if (ValidateProduct(eventMember))
            {
                _eventMembersRepository.AddEventMember(eventMember);
            }
            else
            {
                throw new ArgumentException("Invalid product data");
            }
        }

        public void UpdateEventMember(EventsMember eventMember)
        {
            if (ValidateProduct(eventMember))
            {
                _eventMembersRepository.UpdateEventMember(eventMember);
            }
            else
            {
                throw new ArgumentException("Invalid eventguide data");
            }
        }

        public void DeleteEventMember(int id)
        {
            _eventMembersRepository.DeleteEventMember(id);
        }
        private bool ValidateProduct(EventsMember eventMember)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the price is valid

            if (string.IsNullOrWhiteSpace(eventMember.Events.Name))
            {
                return false;
            }

            return true;
        }

        public void JoinEvent(int EventId, int MemberId)
        {
            _eventMembersRepository.JoinEvent(EventId, MemberId);
        }
    }
}
