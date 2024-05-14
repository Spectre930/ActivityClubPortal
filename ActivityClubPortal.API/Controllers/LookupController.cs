using ActivityClubPortal.API.Resources;
using AutoMapper;
using ids.core.Models;
using ids.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        private readonly IMapper _mapper;

        public LookupController(ILookupService lookupService, IMapper mapper)
        {
            _lookupService = lookupService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<LookupResource>> GetAllLookups()
        {
            var Lookups = _lookupService.GetAllLookups();
            var LookupResource = _mapper.Map<IEnumerable<Lookup>, IEnumerable<LookupResource>>(Lookups);
            return Ok(LookupResource);
        }

        [HttpGet("{id}")]
        public ActionResult<LookupResource> GetLookupById(int id)
        {
            var Lookups = _lookupService.GetLookupById(id);
            if (Lookups == null)
            {
                return NotFound();
            }

            var LookupResource = _mapper.Map<Lookup, LookupResource>(Lookups);
            return Ok(LookupResource);
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public ActionResult<LookupResource> Create(LookupResource LookupResource)
        {
            var Lookups = _mapper.Map<LookupResource, Lookup>(LookupResource);
            _lookupService.AddLookup(Lookups);

            // Update the productViewModel with the generated Id
            LookupResource.Id = Lookups.Id;

            return Ok(LookupResource);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(LookupResource LookupResource)
        {
            var existingProduct = _lookupService.GetLookupById(LookupResource.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var Lookups = _mapper.Map<LookupResource, Lookup>(LookupResource);
            _lookupService.UpdateLookup(Lookups);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _lookupService.GetLookupById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _lookupService.DeleteLookup(id);

            return Ok();
        }
    }
}
