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
        [HttpGet("check-username")]
        public ActionResult UserNameValidation([FromQuery] string username)
        {
            return Ok(registerService
                .CheckUserNameAvailability(username));

        }

        [AllowAnonymous]
        [HttpGet("check-phone")]
        public ActionResult PhoneValidation([FromQuery] string phone)
        {
            return Ok(registerService
                .CheckPhoneAvailability(phone));
        }
    }
}
