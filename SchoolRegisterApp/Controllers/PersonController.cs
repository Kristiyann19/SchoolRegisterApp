using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Attributes;
using SchoolRegisterApp.Models.Dtos.PersonDtos;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Repositories.CustomExceptions;

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
        public async Task<IActionResult> GetAllAsync([FromQuery] PersonFilterDto filter, [FromQuery] int page = 1, [FromQuery] int pageSize = 3)
        {
            return Ok(await personService
                .GetAllPeopleWithFilterAsync(HttpContext, filter, page, pageSize));
        }

        [HttpGet]
        [Route("Count")]
        public async Task<IActionResult> TotalPeople()
        {
            var totalPeople = await personService
                .GetPeopleCount();

            return Ok(totalPeople);
        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDetailsById([FromRoute] int id)
        {
            return Ok(await personService
                .GetPersonDetailsAsync(id));
        }

        [HttpPut("{id:int}")]
        [AuthorizedAdmin]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] PersonDetailsDto updatedPerson)
        {
            await personService
                .UpdatePersonAsync(id, updatedPerson, HttpContext);

            return Ok();
        }

        [HttpPost]
        [AuthorizedAdmin]
        public async Task<IActionResult> AddPersonAsync([FromBody] PersonDetailsDto personAddDto)
        {
            await personService
                .AddPersonAsync(personAddDto, HttpContext);

            return Ok();
        }
    }
}
