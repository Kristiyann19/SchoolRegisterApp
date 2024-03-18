﻿using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;
using SchoolRegisterApp.Models.Dtos.PersonDtos;

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

        public async Task<IEnumerable<SchoolDto>> GetAllSchoolsWithFilterAsync(SchoolFilterDto filter)
        {
            var schools = context.Schools.AsQueryable();

            if (filter != null)
            {
                schools = filter.WhereBuilder(schools);

            }

            var filteredSchools = await schools
                  .ProjectTo<SchoolDto>(mapper.ConfigurationProvider)
                  .Skip((filter.Page - 1) * filter.PageSize)
                  .Take(filter.PageSize)
                  .ToListAsync();

            return filteredSchools;
        }

        public async Task<int> GetSchoolsCount()
           => await context.Schools.CountAsync();
    }
}
