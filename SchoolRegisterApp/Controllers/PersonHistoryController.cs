using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonHistoryController : BaseController
    {
        private readonly IPersonHistoryService personHistoryService;

        public PersonHistoryController(IPersonHistoryService _personHistoryService)
        {
            personHistoryService = _personHistoryService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPersonHistory([FromRoute] int id)
        {
            return Ok(await personHistoryService
                .GetPersonHistoryByPersonIdAsync(id));
        }
    }
}
