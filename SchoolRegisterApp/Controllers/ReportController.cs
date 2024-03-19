using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : BaseController
    {
        private readonly IReportService reportService;

        public ReportController(IReportService _reportService)
        {
            reportService = _reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReport()
        {
            return Ok(await reportService
                .GetPersonCountGroupedBySchooAndPosition());
        }
    }
}
