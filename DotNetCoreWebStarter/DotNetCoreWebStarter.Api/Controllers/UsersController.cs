using DotNetCoreWebStarter.Core.Interfaces;
using DotNetCoreWebStarter.Core.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebStarter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetUsers([FromBody] UserFilterRequest request)
        {
            var result = await _userService.GetUsersAsync(request);
            return Ok(result);
        }
    }
}
