using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Repositories.Services;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("CurrentData")]
        public async Task<IActionResult> GetUserData()
        {
            return Ok(await userService
                .GetUserDataAsync(HttpContext));
        }
    }
}
