using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Attributes;
using SchoolRegisterApp.Models.Dtos.PersonSchoolDtos;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonSchoolController : BaseController
    {
        private readonly IPersonSchoolService personSchoolService;

        public PersonSchoolController(IPersonSchoolService _personSchoolService)
        {
            personSchoolService = _personSchoolService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPersonSchool(int id)
        {
            return Ok(await personSchoolService
                .GetPersonSchoolByPersonIdAsync(id));
        }

        [HttpPost()]
        [AuthorizedDirector]
        public async Task<IActionResult> AddPersonSchool([FromBody] PersonSchoolAddDto personSchoolAddDto)
        {
            await personSchoolService
                .AddPersonSchoolAsync(personSchoolAddDto, HttpContext);

            return Ok();
        }

        [HttpPut()]
        [AuthorizedDirector]
        public async Task<IActionResult> UpdatePersonSchool([FromBody] PersonSchoolUpdateDto personSchoolUpdateDto)
        {
            await personSchoolService
                .UpdatePersonSchoolAsync(personSchoolUpdateDto, HttpContext);

            return Ok();
        }
    }
}
