using System.Security.Claims;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Entities;

using SchoolRegisterApp.Models.Enums;

using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Repositories.Services
{
    public class PersonService : IPersonService
    {
        private readonly SchoolRegisterDbContext context;
        private readonly IMapper mapper;

        public PersonService(SchoolRegisterDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task AddPersonAsync(PersonAddDto personAddDto, HttpContext httpContext)
        {
            var existingUserClaim = httpContext.User
                .FindFirst(ClaimTypes.Name);

            if (existingUserClaim == null)
            {
                throw new Exception("Invalid user");
            }

            var user = await context.Users.SingleOrDefaultAsync(u => u.Username == existingUserClaim.Value);
            int userId = user.Id;

            DecodeUic(personAddDto);

            Person person = new Person
            {
                FirstName = personAddDto.FirstName,
                MiddleName = personAddDto.MiddleName,
                LastName = personAddDto.LastName,
                Uic = personAddDto.Uic,
                BirthDate = personAddDto.BirthDate,
                Gender = personAddDto.Gender,
                BirthPlaceId = personAddDto.BirthPlaceId
            };

            await context.AddAsync(person);
            await context.SaveChangesAsync();

            PersonHistory personHistory = new PersonHistory
            {
                PersonId = person.Id,
                UserId = userId,
                ActionDate = DateTime.UtcNow,
                DataModified =DataModified.Person,
                ModificationType = ModificationType.Created
            };

            await context.AddAsync(personHistory);
            await context.SaveChangesAsync();
        }

        public async Task<List<PersonDto>> GetAllPeopleAsync()
            => await context.People
                .ProjectTo<PersonDto>(mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<List<PersonDto>> GetFilteredPeopleAsync(PersonFilterDto filter) 
            => await filter
                  .WhereBuilder(context.People.AsQueryable())
                  .ProjectTo<PersonDto>(mapper.ConfigurationProvider)
                  .ToListAsync();


        public async Task<PersonDetailsDto> GetPersonDetailsAsync(int id)
            => await context.People
                  .ProjectTo<PersonDetailsDto>(mapper.ConfigurationProvider)    
                  .FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdatePersonAsync(int id, PersonDetailsDto updatedPerson)
        {
            var existingPerson = await context.People
                .FirstOrDefaultAsync(x => x.Id == id);

            mapper.Map(updatedPerson, existingPerson);

            await context.SaveChangesAsync();

        }


        private void DecodeUic(PersonAddDto personAddDto)
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
            int month = int.Parse(monthAsString.Replace("0", ""));
            int date = int.Parse(dateAsString.Replace("0", ""));

            DateTime birthDate = new DateTime(year, month, date);

            int lastUicDigit = int.Parse(personAddDto.Uic.Substring(9, 1));

            GenderEnum gender = lastUicDigit % 2 == 0 
                ? GenderEnum.Female 
                : GenderEnum.Male;

            if (personAddDto.Gender != gender || personAddDto.BirthDate != birthDate)
            {
                throw new Exception("Invalid uic");
            }

            personAddDto.BirthDate = birthDate;
            personAddDto.Gender = gender;

        }
    }
}
