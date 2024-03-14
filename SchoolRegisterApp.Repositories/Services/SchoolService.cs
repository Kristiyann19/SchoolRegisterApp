using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SchoolRegisterApp.Repositories.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolRegisterDbContext context;
        private readonly IMapper mapper;

        public SchoolService(SchoolRegisterDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync()
            => await context.Schools
               .ProjectTo<SchoolDto>(mapper.ConfigurationProvider)
               .ToListAsync();
        

        public async Task<IEnumerable<SchoolDto>> GetFilteredSchoolsAsync(SchoolFilterDto schoolFilter)
        {
            var schools = await schoolFilter
                .WhereBuilder(context.Schools.AsQueryable())
                .ProjectTo<SchoolDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return schools;
        }

        public async Task<SchoolIdAndNameDto> GetSchoolByUserAsync(HttpContext httpContext)
        {
            var existingUserClaim = httpContext.User
                .FindFirst(ClaimTypes.Name);

            if (existingUserClaim == null)
            {
                throw new Exception("Invalid user");
            }

            var username = existingUserClaim.Value;
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);

            var school = await context.Schools
                .FirstOrDefaultAsync(s => s.Id == user.SchoolId);

            if (school == null)
            {
                throw new Exception("Invalid school");
            }

            var schoolToReturn = new SchoolIdAndNameDto()
            {
                Id = school.Id,
                Name = school.Name
            };

            return schoolToReturn;
        }
    }
}
