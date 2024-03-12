using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettlementController : BaseController
    {
        private readonly ISettlementService settlementService;

        public SettlementController(ISettlementService _settlementService)
        {
            settlementService = _settlementService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSettlements()
        {
            return Ok(await settlementService
                .GetAllSettlementsAsync());
        }
    }
}
