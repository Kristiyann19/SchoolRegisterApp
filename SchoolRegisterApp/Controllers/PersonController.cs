using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService _personService)
        {
            personService = _personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await personService
                .GetAllPeopleAsync());
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> GetFilteredAsync([FromQuery] PersonFilterDto filter)
        {
            return Ok(await personService
                .GetFilteredPeopleAsync(filter));
        }
    }
}
