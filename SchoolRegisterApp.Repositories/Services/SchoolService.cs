using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;
using SchoolRegisterApp.Models.Dtos.PersonDtos;
using SchoolRegisterApp.Models.Enums;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Repositories.CustomExceptions;
using SchoolRegisterApp.Repositories.Validations;

namespace SchoolRegisterApp.Repositories.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolRegisterDbContext context;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public SchoolService(SchoolRegisterDbContext _context, IMapper _mapper, IUserService _userService)
        {
            context = _context;
            mapper = _mapper;
            userService = _userService;
        }

        public async Task AddSchoolAsync(HttpContext httpContext, AddSchoolDto school)
        {
            var user = await userService.GetCurrentUser(httpContext);

            if (user.Role != RoleEnum.Admin)
            {
                throw new Exception();
            }

            SchoolValidator validator = new SchoolValidator();
            var result = validator.Validate(school);

            foreach (var failure in result.Errors)
            {
                if (failure.CustomState is BadRequestException bre)
                {
                    throw bre;
                }
            }

            var schoolEntity = mapper.Map<School>(school);
            schoolEntity.IsActive = true;

            await context.AddAsync(schoolEntity);
            await context.SaveChangesAsync();
        }

        public async Task<SearchResultDto<SchoolDto>> GetAllSchoolsWithFilterAsync(SchoolFilterDto filter)
        {
            var schools = context.Schools.AsQueryable();

            if (filter != null)
            {
                schools = filter.WhereBuilder(schools);

            }

            var count = await schools.CountAsync();

            var filteredSchools = await schools
                  .ProjectTo<SchoolDto>(mapper.ConfigurationProvider)
                  .Skip((filter.Page - 1) * filter.PageSize)
                  .Take(filter.PageSize)
                  .ToListAsync();

            return new SearchResultDto<SchoolDto>
            {
                Items = filteredSchools,
                TotalCount = count
            };
        }


        public async Task<List<SchoolDto>> GetAllSchools()
            => await context.Schools
            .ProjectTo<SchoolDto>(mapper.ConfigurationProvider)
            .ToListAsync();    
    }
}
