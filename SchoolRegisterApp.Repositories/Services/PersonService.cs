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

        public async Task AddPersonAsync(PersonDetailsDto personAddDto, HttpContext httpContext)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    var existingUserClaim = httpContext.User
                        .FindFirst(ClaimTypes.Name);

                    if (existingUserClaim == null)
                    {
                        throw new Exception("Invalid user");
                    }

                    var user = await context.Users.SingleOrDefaultAsync(u => u.Username == existingUserClaim.Value);

                    if (user.Role != RoleEnum.Admin)
                    {
                        throw new Exception("You are not an admin");
                    }

                    DecodeUic(personAddDto);

                    var person = new Person
                    {
                        FirstName = personAddDto.FirstName,
                        MiddleName = personAddDto.MiddleName,
                        LastName = personAddDto.LastName,
                        Uic = personAddDto.Uic,
                        BirthDate = personAddDto.BirthDate,
                        Gender = personAddDto.Gender,
                        BirthPlaceId = personAddDto.BirthPlaceId
                    };

                    await context.People.AddAsync(person);
                    await context.SaveChangesAsync();

                    var personHistory = new PersonHistory
                    {
                        PersonId = person.Id,
                        UserId = user.Id,
                        ActionDate = DateTime.UtcNow,
                        DataModified = DataModified.Person,
                        ModificationType = ModificationType.Created
                    };

                    await context.PersonHistories.AddAsync(personHistory);
                    await context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<List<PersonDto>> GetAllPeopleAsync(HttpContext httpContext)
        {
            var existingUserClaim = httpContext.User
                        .FindFirst(ClaimTypes.Name);

            if (existingUserClaim == null)
            {
                throw new Exception("Invalid user");
            }

            var user = await context.Users.SingleOrDefaultAsync(u => u.Username == existingUserClaim.Value);

            var people = context.People.AsQueryable();

            if (user.Role == RoleEnum.Director)
            {
                people = people.Where(x => x.SchoolId == user.SchoolId || x.SchoolId == null);
            }

            return await people
                    .ProjectTo<PersonDto>(mapper.ConfigurationProvider)
                  .ToListAsync();
        }

        public async Task<List<PersonDto>> GetFilteredPeopleAsync(PersonFilterDto filter)
            => await filter
                  .WhereBuilder(context.People.AsQueryable())
                  .ProjectTo<PersonDto>(mapper.ConfigurationProvider)
                  .ToListAsync();


        public async Task<PersonDetailsDto> GetPersonDetailsAsync(int id)
            => await context.People
                  .Include(x => x.School)
                  .ProjectTo<PersonDetailsDto>(mapper.ConfigurationProvider)
                  .FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdatePersonAsync(int id, PersonDetailsDto updatedPerson, HttpContext httpContext)
        {
            var existingUserClaim = httpContext.User
                .FindFirst(ClaimTypes.Name);

            if (existingUserClaim == null)
            {
                throw new Exception("Invalid user");
            }

            var user = await context.Users.SingleOrDefaultAsync(u => u.Username == existingUserClaim.Value);
            int userId = user.Id;


            var existingPerson = await context.People
                .FirstOrDefaultAsync(x => x.Id == id);

            DecodeUic(updatedPerson);

            mapper.Map(updatedPerson, existingPerson);

            var personHistory = new PersonHistory
            {
                PersonId = updatedPerson.Id,
                UserId = userId,
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
