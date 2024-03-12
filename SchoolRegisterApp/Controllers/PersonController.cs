using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
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

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDetailsById([FromRoute] int id)
        {
            return Ok(await personService
                .GetPersonDetailsAsync(id));
        }

        [HttpPut("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] PersonDetailsDto updatedPerson)
        {
            await personService
                .UpdatePersonAsync(id, updatedPerson);

            return Ok();
        }
    }
}
