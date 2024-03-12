using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Entities;
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
    }
}
