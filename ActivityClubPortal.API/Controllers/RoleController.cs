using ActivityClubPortal.API.Resources;
using AutoMapper;
using Elfie.Serialization;
using ids.core.Models;
using ids.services;
using ids.services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ActivityClubPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRole(int id)
        {
            var role = _roleService.GetRoleById(id);
            var res = _mapper.Map<Role, RoleResource>(role);
            return Ok(res);
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var roleList = _roleService.GetAllRoles();
            var res = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(roleList);
            return Ok(res);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(RoleResource resource)
        {
            var role = _mapper.Map<RoleResource, Role>(resource);

            _roleService.AddRole(role);
            return Ok(role);

        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(RoleResource resource)
        {
            var role = _roleService.GetRoleById(resource.Id);

            if (role == null)
            {
                return NotFound();
            }

            role = _mapper.Map<RoleResource, Role>(resource);

            _roleService.UpdateRole(role);
            return Ok(role);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var role = _roleService.GetRoleById(id);

            if (role == null)
            {
                return NotFound();
            }

            _roleService.DeleteRole(id);
            return Ok("Role Deleted!");
        }
    }
}
