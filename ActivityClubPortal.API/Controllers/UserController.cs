using ActivityClubPortal.API.Resources;
using AutoMapper;
using ids.core.Models;
using ids.core.ViewModels;
using ids.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ActivityClubPortal.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        [HttpGet("getall")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<UserResource>> GetAllUsers()
        {
            var user = _userService.GetAllUsers();
            var userResource = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(user);

            return Ok(userResource);
        }

        [HttpGet("{id}")]
        public ActionResult<UserResource> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var userResource = _mapper.Map<User, UserResource>(user);
            return Ok(userResource);
        }

        [HttpGet("GetByEmail")]
        public ActionResult<UserResource> GetUserByEmail(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }

            var userResource = _mapper.Map<User, UserResource>(user);
            return Ok(userResource);
        }

        [HttpPost("create")]
        public ActionResult<UserResource> Create(UserResource userResource)
        {
            var obj = _userService.GetUserByEmail(userResource.Email);
            if (obj != null)
            {
                return BadRequest("Email Already Exists!");
            }

            var user = _mapper.Map<UserResource, User>(userResource);
            _userService.AddUser(user);
            userResource.Id = user.Id;

            return Ok(userResource);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<UserResource> LoginUser(LoginVm vm)
        {
            try
            {
                var token = _userService.LoginUser(vm);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("update/{id}")]
        public IActionResult Update(UserResource userResource)
        {


            var existingProduct = _userService.GetUserById(userResource.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<UserResource, User>(userResource);
            _userService.UpdateUser(user);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _userService.GetUserById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);

            return Ok();
        }

        [HttpPost("{id}/addRole")]
        public IActionResult AddRole(int id, int RoleId)
        {

            _userService.AddRole(id, RoleId);
            return Ok();
        }
    }

}
