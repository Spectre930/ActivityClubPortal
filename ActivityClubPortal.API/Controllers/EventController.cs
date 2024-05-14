using ActivityClubPortal.API.Resources;
using ActivityClubPortal.API.Resources.Viewmodels;
using AutoMapper;
using ids.core.Models;
using ids.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Tracing;


namespace ActivityClubPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IEventGuidesService _eventGuidesService;
        private readonly IEventMembersService _eventMembersService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper, IEventGuidesService eventGuidesService, IEventMembersService eventMembersService)
        {
            _eventService = eventService;
            _mapper = mapper;
            _eventGuidesService = eventGuidesService;
            _eventMembersService = eventMembersService;
        }

        [HttpGet("getall")]
        public ActionResult<IEnumerable<EventsVm>> GetAllEvents()
        {
            var events = _eventService.GetAllEvents();
            var eventResource = new List<EventsVm>();
            foreach (Event e in events)
            {
                var ev = _mapper.Map<Event, EventResource>(e);
                var lu = _mapper.Map<Lookup, LookupResource>(e.Lookup);
                eventResource.Add(new EventsVm
                {
                    Event = ev,
                    Lookup = lu
                });
            }
            return Ok(eventResource);
        }

        [HttpGet("{id}")]
        public ActionResult<EventsVm> GetEventById(int id)
        {
            var events = _eventService.GetEventById(id);
            if (events == null)
            {
                return NotFound();
            }

            var resObject = new EventsVm
            {
                Event = _mapper.Map<Event, EventResource>(events),
                Lookup = _mapper.Map<Lookup, LookupResource>(events.Lookup)
            };

            return Ok(resObject);
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public ActionResult<EventResource> Create(EventResource eventResource)
        {

            var events = _mapper.Map<EventResource, Event>(eventResource);
            _eventService.AddEvent(events);

            // Update the productViewModel with the generated Id
            eventResource.Id = events.Id;

            return Ok(eventResource);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(EventResource eventResource)
        {

            var existingProduct = _eventService.GetEventById(eventResource.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var events = _mapper.Map<EventResource, Event>(eventResource);
            _eventService.UpdateEvent(events);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _eventService.GetEventById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _eventService.DeleteEvent(id);

            return Ok();
        }

        [HttpGet]
        [Route("{id}/guides")]
        public IActionResult GetEventGuides(int id)
        {
            var existingProduct = _eventService.GetEventById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var guides = _eventGuidesService.GetGuidesOfEvent(id);
            var res = _mapper.Map<IEnumerable<Guide>, IEnumerable<GuideResource>>(guides);
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id}/guides/dropGuide")]
        public IActionResult DropGuide(int id, int GuideId)
        {
            _eventGuidesService.DropGuideFromEvent(id, GuideId);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/guides/add")]
        public IActionResult AddGuide(int id, int GuideId)
        {
            _eventGuidesService.AddGuideToEvent(id, GuideId);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/SetLookUp")]
        public IActionResult SetLookUp(int id, int LookUpId)
        {
            _eventService.SetLookup(id, LookUpId);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/Members")]
        public IActionResult GetMembers(int id)
        {
            try
            {
                var members = _eventService.GetMembers(id);
                var res = _mapper.Map<IEnumerable<Member>, IEnumerable<MemberResource>>(members);
                return Ok(members);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("{id}/Join")]
        [Authorize(Roles = "Member")]
        public IActionResult JoinEvent(int memberId, int id)
        {
            _eventMembersService.JoinEvent(id, memberId);
            return Ok();
        }

    }

}

