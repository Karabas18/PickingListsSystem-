using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PickingListsSystem.Dto.User;
using PickingListsSystem.Services.Contracts;
using System.Net;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        protected readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> GetProfile(string userId)
        {
            return await _authService.GetProfile(userId);
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.Register(request);

            return result.Success ? Ok(result) : BadRequest(result.Message);

        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.Login(request);

            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost]
        [Route("refresh")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        public async Task<IActionResult> Refresh(RefreshTokenRequest request)
        {
            var result = await _authService.Refresh(request);

            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}