using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.User;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAll()
        {
            return await _userService.GetUser();
        }

        [HttpGet("getbyid")]
        public async Task<UserDto> GetID(int id)
        {
            return await _userService.GetUserID(id);
        }

        [HttpPost]
        public async Task<string> Create([FromBody] CreateUserDto user)
        {
            return await _userService.AddUser(user);
        }

        [HttpPut]
        public async Task<string> Update([FromBody] UserDto user)
        {
            return await _userService.UpdateUser(user);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _userService.DeleteUser(id);
        }

    }
}