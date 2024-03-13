using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
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

        public async Task<List<PersonSchoolDto>> GetPersonSchoolByPersonIdAsync(int id)
            => await context.PersonSchools
                .ProjectTo<PersonSchoolDto>(mapper.ConfigurationProvider)
                .Where(x => x.PersonId == id)
                .ToListAsync();
        
    }
}
