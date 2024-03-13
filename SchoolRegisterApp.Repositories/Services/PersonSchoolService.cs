using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Repositories.Services
{
    public class PersonSchoolService : IPersonSchoolService
    {
        private readonly SchoolRegisterDbContext context;
        private readonly IMapper mapper;

        public PersonSchoolService(SchoolRegisterDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;

        }

        public async Task AddPersonSchoolAsync(PersonSchoolAddDto personSchoolAddDto, HttpContext httpContext)
        {
            var existingUserClaim = httpContext.User
                        .FindFirst(ClaimTypes.Name);

            if (existingUserClaim == null)
            {
                throw new Exception("Invalid user");
            }

            var username = existingUserClaim.Value;
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (personSchoolAddDto.SchoolId != user.SchoolId)
            {
                throw new Exception("Invalid school");
            }

            PersonSchool personSchool = new PersonSchool()
            {
                Position = personSchoolAddDto.Position,
                PersonId = personSchoolAddDto.PersonId,
                SchoolId = personSchoolAddDto.SchoolId,
                StartDate = personSchoolAddDto.StartDate,
                EndDate = personSchoolAddDto.EndDate != null
                    ? personSchoolAddDto.EndDate
                    : null
            };

            await context.AddAsync(personSchool);

            PersonHistory personHistory = new PersonHistory()
            {
                PersonId = personSchoolAddDto.PersonId,
                UserId = user.Id,
                ActionDate = DateTime.UtcNow,
                DataModified = DataModified.PersonSchool,
                ModificationType = ModificationType.Created
            };

            await context.AddAsync(personHistory);
            await context.SaveChangesAsync();
        }

        public async Task<List<PersonSchoolDto>> GetPersonSchoolByPersonIdAsync(int id)
            => await context.PersonSchools
                .ProjectTo<PersonSchoolDto>(mapper.ConfigurationProvider)
                .Where(x => x.PersonId == id)
                .ToListAsync();
        
    }
}
