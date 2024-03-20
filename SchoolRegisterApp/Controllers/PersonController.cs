using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Attributes;
using SchoolRegisterApp.Models.Dtos.PersonDtos;
using SchoolRegisterApp.Models.Enums;
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
        public async Task<IActionResult> GetAllAsync([FromQuery] PersonFilterDto filter)
        {
            return Ok(await personService
                .GetAllPeopleWithFilterAsync(HttpContext, filter));
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDetailsById([FromRoute] int id)
        {
            return Ok(await personService
                .GetPersonDetailsAsync(id));
        }

        [HttpPut("{id:int}")]
        [AuthorizedUser(RoleEnum.Admin)]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] PersonDetailsDto updatedPerson)
        {
            await personService
                .UpdatePersonAsync(id, updatedPerson, HttpContext);

            return Ok();
        }

        [HttpPost]
        [AuthorizedUser(RoleEnum.Admin)]
        public async Task<IActionResult> AddPersonAsync([FromBody] PersonDetailsDto personAddDto)
        {
            await personService
                .AddPersonAsync(personAddDto, HttpContext);

            return Ok();
        }
    }
}
