using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Repositories.Contracts;

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
        public async Task<IActionResult> GetAllSchools()
        {
            return Ok(await schoolService
                .GetAllSchoolsAsync());
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetFilteredSchools([FromQuery] SchoolFilterDto schoolFilter)
        {
            return Ok(await schoolService
                .GetFilteredSchoolsAsync(schoolFilter));
        }
    }
}
