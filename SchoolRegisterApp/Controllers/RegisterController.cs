using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Models.Dtos.UserDtos;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Repositories.CustomExceptions;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : BaseController
    {
        private readonly IRegisterService registerService;

        public RegisterController(IRegisterService _registerService)
        {
            registerService = _registerService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register([FromBody] RegisterDto register)
        {
            try
            {
                registerService.Register(register);

                return Ok();
            }
            catch (BadRequestException bre)
            {
                return NotFound(bre.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("check-username/{username}")]
        public ActionResult UserNameValidation([FromBody] string username)
        {
            var isAvailable = registerService.CheckUserNameAvailability(username);

            return Ok(isAvailable);
        }

        [AllowAnonymous]
        [HttpGet("check-phone/{phone}")]
        public ActionResult PhoneValidation([FromBody] string phone)
        {
            var isAvailable = registerService.CheckPhoneAvailability(phone);

            return Ok(isAvailable);
        }
    }
}
