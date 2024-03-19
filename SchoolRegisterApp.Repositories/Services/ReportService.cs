using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Repositories.Services
{
    public class ReportService : IReportService
    {
        private readonly SchoolRegisterDbContext context;

        public ReportService(SchoolRegisterDbContext _context)
        {
            context = _context;
        }

        public async Task<List<ReportDto>> GetPersonCountGroupedBySchooAndPosition()
            => await context.PersonSchools
                .GroupBy(ps => new { ps.SchoolId, ps.Position })
                .Select(g => new ReportDto
                {
                    SchoolId = g.Key.SchoolId,
                    School = g.FirstOrDefault().School,
                    Position = g.Key.Position,
                    PeopleCount = g.Count()

                })
                .ToListAsync();
    }
}
