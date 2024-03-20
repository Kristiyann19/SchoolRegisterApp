using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Attributes;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;
using SchoolRegisterApp.Models.Enums;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Repositories.Services;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : BaseController
    {
        private readonly ISchoolService schoolService;

        public SchoolController(ISchoolService _schoolService)
        {
            schoolService = _schoolService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSchools([FromQuery] SchoolFilterDto filter)
        {
            return Ok(await schoolService
                .GetAllSchoolsWithFilterAsync(filter));
        }


        [HttpPost]
        [AuthorizedUser(RoleEnum.Admin)]
        public async Task<IActionResult> AddSchool([FromBody] AddSchoolDto school)
        {
            await schoolService
                .AddSchoolAsync(HttpContext, school);

            return Ok();
        }

        [HttpGet("All")]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return Ok(await schoolService
                .GetAllSchools());
        }
    }
}
