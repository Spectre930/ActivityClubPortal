using ActivityClubPortal.API.Resources;
using AutoMapper;
using ids.core.Models;
using ids.core.ViewModels;
using ids.services;
using ids.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;

        public MemberController(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles="Admin")]
        public IActionResult Get(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<Member, MemberResource>(member);

            return Ok(res);
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var memberList = _memberService.GetAllMembers();
            var res = _mapper.Map<IEnumerable<Member>, IEnumerable<MemberResource>>(memberList);
            return Ok(res);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(MemberResource resource)
        {
            var obj = _memberService.GetMemberByEmail(resource.Email);
            if (obj != null)
            {
                return BadRequest("Email Already Exists!");
            }
            var member = _mapper.Map<MemberResource, Member>(resource);

            _memberService.AddMember(member);
            return Ok(member);

        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(MemberResource resource)
        {
            var obj = _memberService.GetMemberById(resource.Id);
            if (obj == null)
            {
                return NotFound();
            }

            var member = _mapper.Map<MemberResource, Member>(resource);

            _memberService.UpdateMember(member);
            return Ok(member);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _memberService.GetMemberById(id);
            if (obj == null)
            {
                return NotFound();
            }

            _memberService.DeleteMember(id);
            return Ok("member Deleted!");
        }

        [HttpGet]
        [Route("{id}/events")]
        public IActionResult GetEvents(int id)
        {
            try
            {
                var events = _memberService.GetEvents(id);
                var res = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<UserResource> LoginUser(LoginVm vm)
        {
            try
            {
                var token = _memberService.LoginMember(vm);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
