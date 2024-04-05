using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Role;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<RoleDto>> GetAll()
        {
            return await _roleService.GetRole();
        }

        [HttpGet("getbyid")]
        public async Task<RoleDto> GetID(int id)
        {
            return await _roleService.GetRoleID(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateRoleDto role)
        {
            return await _roleService.AddRole(role);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] RoleDto role)
        {
            return await _roleService.UpdateRole(role);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _roleService.DeleteRole(id);
        }

    }
}