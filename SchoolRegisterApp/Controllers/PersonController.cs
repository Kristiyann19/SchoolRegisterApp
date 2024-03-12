using Microsoft.AspNetCore.Authorization;
<<<<<<< HEAD
using Microsoft.AspNetCore.Cors.Infrastructure;
=======
>>>>>>> 4ede17321f1a302f9e3a1a52a445dcf64322833c
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

<<<<<<< HEAD
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
=======
        [HttpPost("Add")]
        [AllowAnonymous]
        public async Task<IActionResult> AddPersonAsync([FromBody] PersonAddDto personAddDto)
        {
            await personService
                .AddPersonAsync(personAddDto, HttpContext);
>>>>>>> 4ede17321f1a302f9e3a1a52a445dcf64322833c

            return Ok();
        }
    }
}
