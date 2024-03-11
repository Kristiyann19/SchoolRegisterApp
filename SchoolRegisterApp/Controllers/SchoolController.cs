using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Controllers
{
    public class SchoolController : BaseController
    {
        private readonly ISchoolService schoolService;

        public SchoolController(ISchoolService _schoolService)
        {
            schoolService = _schoolService;
        }

        public async Task<IActionResult> GetAllSchools()
        {
            return Ok(await schoolService
                .GetAllSchoolsAsync());
        }
    }
}
