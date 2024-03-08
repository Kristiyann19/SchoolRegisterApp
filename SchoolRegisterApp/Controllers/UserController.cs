using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Repositories.Services;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [AllowAnonymous]
        [HttpGet("CurrentUser")]
        public async Task<IActionResult> GetUserData()
        {
            return Ok(await userService
                .GetUserDataAsync(HttpContext));
        }
    }
}
