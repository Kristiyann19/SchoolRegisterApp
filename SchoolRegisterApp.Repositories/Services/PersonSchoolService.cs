﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Models.Dtos.PersonSchoolDtos;
using SchoolRegisterApp.Repositories.CustomExceptions;
using SchoolRegisterApp.Repositories.CustomExceptionMessages;

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

            var username = existingUserClaim.Value;
            var user = await context.Users
                .SingleOrDefaultAsync(u => u.Username == username);

            if (personSchoolAddDto.SchoolId != user.SchoolId)
            {
                throw new NotFoundException(ExceptionMessages.InvalidSchool);
            }

            var personSchool = mapper.Map<PersonSchool>(personSchoolAddDto);

            var updatedPerson = await context.People.SingleOrDefaultAsync(x => x.Id == personSchool.PersonId);

            await context.AddAsync(personSchool);

            updatedPerson.SchoolId = personSchool.SchoolId;

            var personHistory = new PersonHistory()
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

        public async Task UpdatePersonSchoolAsync(PersonSchoolUpdateDto personSchoolUpdateDto, HttpContext httpContext)
        {
            var existingUserClaim = httpContext.User
                        .FindFirst(ClaimTypes.Name);

            var username = existingUserClaim.Value;
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (personSchoolUpdateDto.SchoolId != user.SchoolId)
            {
                throw new NotFoundException(ExceptionMessages.InvalidSchool);
            }

            var personSchoolToUpdate = await context.PersonSchools
                .SingleOrDefaultAsync(ps => ps.Id ==  personSchoolUpdateDto.Id);

            if (personSchoolToUpdate == null)
            {
                throw new NotFoundException(ExceptionMessages.InvalidPersonSchool);
            }

            if (personSchoolToUpdate.PersonId != personSchoolUpdateDto.PersonId)
            {
                throw new BadRequestException(ExceptionMessages.CannotChangePersonForPersonSchool);
            }

            if (personSchoolToUpdate.SchoolId != personSchoolUpdateDto.SchoolId)
            {
                throw new BadRequestException(ExceptionMessages.CannotChangeSchoolForPersonSchool);
            }

            personSchoolToUpdate.Position = personSchoolUpdateDto.Position;
            personSchoolToUpdate.StartDate = personSchoolUpdateDto.StartDate;
            personSchoolToUpdate.EndDate = personSchoolUpdateDto.EndDate;

            var personHistory = new PersonHistory()
            {
                PersonId = personSchoolUpdateDto.PersonId,
                UserId = user.Id,
                ActionDate = DateTime.UtcNow,
                DataModified = DataModified.PersonSchool,
                ModificationType = ModificationType.Updated
            };

            await context.AddAsync(personHistory);
            await context.SaveChangesAsync();
        }
    }
}
