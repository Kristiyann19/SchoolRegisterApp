using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
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





       
    }
}
