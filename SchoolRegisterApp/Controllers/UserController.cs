using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
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
