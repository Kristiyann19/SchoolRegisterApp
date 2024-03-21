using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Dtos.PersonDtos;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Repositories.CustomExceptionMessages;
using SchoolRegisterApp.Repositories.CustomExceptions;
using SchoolRegisterApp.Repositories.Validations;
using System.Net;

namespace SchoolRegisterApp.Repositories.Services
{
    public class PersonService : IPersonService
    {
        private readonly SchoolRegisterDbContext context;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public PersonService(SchoolRegisterDbContext _context, IMapper _mapper, IUserService _userService)
        {
            context = _context;
            mapper = _mapper;
            userService = _userService;
        }

        public async Task AddPersonAsync(PersonDetailsDto personAddDto, HttpContext httpContext)
        {
            var user = await userService.GetCurrentUser(httpContext);

            PersonValidator validator = new PersonValidator();
            var result = validator.Validate(personAddDto);

            foreach (var failure in result.Errors)
            {
                if (failure.CustomState is BadRequestException bre)
                {
                    throw bre;
                }
            }

            DecodeUic(personAddDto);

            var person = mapper.Map<Person>(personAddDto);

            person.SchoolId = null;

            person.PersonHistories.Add(new PersonHistory()
            {
                UserId = user.Id,
                ActionDate = DateTime.UtcNow,
                DataModified = DataModified.Person,
                ModificationType = ModificationType.Created
            });

            await context.People.AddAsync(person);
            await context.SaveChangesAsync();
        }

        public async Task<SearchResultDto<PersonDto>> GetAllPeopleWithFilterAsync(HttpContext httpContext, PersonFilterDto filter)
        {
            var user = await userService.GetCurrentUser(httpContext);

            var people = context.People.AsQueryable();

            if (user.Role == RoleEnum.Director)
            {
                people = people.Where(x => x.SchoolId == user.SchoolId || x.SchoolId == null);
            }

            if (filter != null)
            {
                people = filter.WhereBuilder(people);

            }

            var count = await people.CountAsync();

            var filteredPeople = await people
                  .ProjectTo<PersonDto>(mapper.ConfigurationProvider)
                  .Skip((filter.Page - 1) * filter.PageSize)
                  .Take(filter.PageSize)
                  .ToListAsync();

            return new SearchResultDto<PersonDto>
            {
                Items = filteredPeople,
                TotalCount = count
            };
        }

        public async Task<PersonDetailsDto> GetPersonDetailsAsync(int id)
            => await context.People
                  .Include(x => x.School)
                  .ProjectTo<PersonDetailsDto>(mapper.ConfigurationProvider)
                  .FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdatePersonAsync(int id, PersonDetailsDto updatedPerson, HttpContext httpContext)
        {
            var user = await userService.GetCurrentUser(httpContext);

            var existingPerson = await context.People
                .SingleOrDefaultAsync(x => x.Id == id);

            if (existingPerson == null)
            {
                throw new NotFoundException(ExceptionMessages.InvalidPerson);
            }

            PersonValidator validator = new PersonValidator();
            var result = validator.Validate(updatedPerson);

            foreach (var failure in result.Errors)
            {
                if (failure.CustomState is BadRequestException bre)
                {
                    throw bre;
                }
            }

            DecodeUic(updatedPerson);

            mapper.Map(updatedPerson, existingPerson);
            
            var personHistory = new PersonHistory
            {
                PersonId = updatedPerson.Id,
                UserId = user.Id,
                ActionDate = DateTime.UtcNow,
                DataModified = DataModified.Person,
                ModificationType = ModificationType.Updated
            };

            await context.AddAsync(personHistory);
            await context.SaveChangesAsync();
        }


        private void DecodeUic(PersonDetailsDto personAddDto)
        {
            const int numberToSubtractFromMonth = 40;

            string bornBefore2000 = "19";
            string bornAfter2000 = "20";

            string lastTwoDigitsOfYear = personAddDto.Uic.Substring(0, 2);
            string monthDigits = personAddDto.Uic.Substring(2, 2);
            string dateDigits = personAddDto.Uic.Substring(4, 2);

            string firstDigitOfMonthDigits = monthDigits.Substring(0, 1);

            string yearAsString = string.Empty;
            string monthAsString = string.Empty;
            string dateAsString = string.Empty;

            if (firstDigitOfMonthDigits == "4" || firstDigitOfMonthDigits == "5")
            {
                yearAsString = bornAfter2000 + lastTwoDigitsOfYear;

                int monthAsDigit = int.Parse(monthDigits) - numberToSubtractFromMonth;
                monthAsString = monthAsDigit.ToString();
            }
            else
            {
                yearAsString = bornBefore2000 + lastTwoDigitsOfYear;

                monthAsString = monthDigits.ToString();
            }

            dateAsString = dateDigits.ToString();

            int year = int.Parse(yearAsString);
            int month = int.Parse(monthAsString);
            int date = int.Parse(dateAsString);

            DateTime birthDate = new DateTime(year, month, date);

            int digitForGender = int.Parse(personAddDto.Uic.Substring(8, 1));

            GenderEnum gender = digitForGender % 2 == 0
                ? GenderEnum.Male
                : GenderEnum.Female;

            personAddDto.BirthDate = personAddDto.BirthDate;
            personAddDto.Gender = personAddDto.Gender;

        }
    }
}
