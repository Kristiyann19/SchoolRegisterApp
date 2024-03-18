using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;

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

        public async Task AddSchoolAsync(HttpContext httpContext, AddSchoolDto school)
        {
            var existingUserClaim = httpContext.User
                        .FindFirst(ClaimTypes.Name);

            var user = await context.Users.SingleOrDefaultAsync(u => u.Username == existingUserClaim.Value);

            var schoolEntity = mapper.Map<School>(school);
            schoolEntity.IsActive = true;

            await context.AddAsync(schoolEntity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync()
        {
            var schools = await context.Schools
               .ProjectTo<SchoolDto>(mapper.ConfigurationProvider)
               .ToListAsync();

            return schools;
        }
        

        public async Task<IEnumerable<SchoolDto>> GetFilteredSchoolsAsync(SchoolFilterDto schoolFilter)
        {
            var schools = await schoolFilter
                .WhereBuilder(context.Schools.AsQueryable())
                .ProjectTo<SchoolDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return schools;
        }
    }
}
