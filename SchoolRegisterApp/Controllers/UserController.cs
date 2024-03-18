using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Models.Dtos.UserDtos;
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

        [HttpGet("CurrentUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserData()
        {
            return Ok(await userService
                .GetUserDataAsync(HttpContext));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userService
                .GetAllUsersAsync());
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> GetFilteredAsync([FromQuery] UserFilterDto userDto)
        {
            List<UserDto> users = await userService.GetFilteredUsersAsync(userDto);

            return Ok(users);
        }
    }
}
