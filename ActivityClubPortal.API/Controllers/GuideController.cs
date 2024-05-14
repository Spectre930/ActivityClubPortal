using ActivityClubPortal.API.Resources;
using AutoMapper;
using ids.core.Models;
using ids.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ActivityClubPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuideController : ControllerBase
    {
        private readonly IGuideService _guideService;
        private readonly IEventGuidesService _eventGuidesService;
        private readonly IMapper _mapper;

        public GuideController(IGuideService guideService, IEventGuidesService eventGuidesService, IMapper mapper)
        {
            _guideService = guideService;
            _eventGuidesService = eventGuidesService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<GuideResource>> GetAllGuides()
        {
            var guide = _guideService.GetAllGuides();
            var guideResource = _mapper.Map<IEnumerable<Guide>, IEnumerable<GuideResource>>(guide);
            return Ok(guideResource);
        }

        [HttpGet("{id}")]
        public ActionResult<GuideResource> GetGuideById(int id)
        {
            var guide = _guideService.GetGuideById(id);
            if (guide == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<Guide, GuideResource>(guide);
            return Ok(productViewModel);
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        public ActionResult<GuideResource> Create(GuideResource guideResource)
        {
            var guide = _mapper.Map<GuideResource, Guide>(guideResource);
            _guideService.AddGuide(guide);

            // Update the productViewModel with the generated Id
            guideResource.Id = guide.Id;

            return Ok(guideResource);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(GuideResource guideResource)
        {

            var existingProduct = _guideService.GetGuideById(guideResource.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var guide = _mapper.Map<GuideResource, Guide>(guideResource);
            _guideService.UpdateGuide(guide);

            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _guideService.GetGuideById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _guideService.DeleteGuide(id);

            return Ok();
        }

        [HttpPost]
        [Route("{id}/guideEvent")]
        public IActionResult GuideAnEvent(int id, int EventId)
        {
            _eventGuidesService.AddGuideToEvent(EventId, id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/events")]
        public IActionResult GetGuidedEvents(int id)
        {
            var events = _eventGuidesService.GetEventsOfaGuide(id);
            var res = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
            return Ok(res);
        }
    }
}
