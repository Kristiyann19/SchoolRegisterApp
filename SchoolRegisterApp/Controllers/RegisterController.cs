using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Repositories.Contracts;

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

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register([FromBody] RegisterDto register)
        {
            registerService.Register(register);

            return Ok();
        }

        [HttpGet("check-username/{username}")]
        public ActionResult UserNameValidation(string username)
        {
            var isAvailable = registerService.CheckUserNameAvailability(username);

            return Ok(isAvailable);
        }

        [HttpGet("check-phone/{phone}")]
        public ActionResult EmailValidation(string phone)
        {
            var isAvailable = registerService.CheckPhoneAvailability(phone);

            return Ok(isAvailable);
        }
    }
}
