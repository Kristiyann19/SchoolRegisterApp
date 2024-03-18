using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;
using SchoolRegisterApp.Models.Enums;

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

            if (existingUserClaim == null)
            {
                throw new Exception("Invalid user");
            }

            var user = await context.Users.SingleOrDefaultAsync(u => u.Username == existingUserClaim.Value);

            if (user.Role == RoleEnum.Director)
            {
                throw new Exception("Only Admins can add schools");
            }

            var schoolEntity = mapper.Map<School>(school);
            schoolEntity.IsActive = true;

            await context.AddAsync(schoolEntity);
            await context.SaveChangesAsync();

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

        public async Task<SchoolIdAndNameDto> GetSchoolByPersonAsync(int personId)
        {
            var person = await context.People
                .FirstOrDefaultAsync(p => p.Id == personId);

            if (person == null)
            {
                throw new Exception("Invalid person");
            }

            if (person.SchoolId == null)
            {
                throw new Exception("Person doesn't have school");
            }

            var school = await context.Schools
                .FirstOrDefaultAsync(s => s.Id == person.SchoolId);

            var schoolToReturn = new SchoolIdAndNameDto()
            {
                Id = school.Id,
                Name = school.Name
            };

            return schoolToReturn;
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

        public async Task<string> GetSchoolNameById(int id)
        {
            var school =  await context.Schools.SingleOrDefaultAsync(x => x.Id == id);

            return school.Name;
        }
    }
}
