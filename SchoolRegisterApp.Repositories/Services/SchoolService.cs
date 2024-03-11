using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Repositories.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolRegisterDbContext context;

        public SchoolService(SchoolRegisterDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync()
        {

        }
    }
}
