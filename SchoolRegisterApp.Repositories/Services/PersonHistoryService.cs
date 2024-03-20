using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Models.Dtos.PersonHistoryDtos;

namespace SchoolRegisterApp.Repositories.Services
{
    public class PersonHistoryService : IPersonHistoryService
    {
        private readonly SchoolRegisterDbContext context;
        private readonly IMapper mapper;

        public PersonHistoryService(SchoolRegisterDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<PersonHistoryDto>> GetPersonHistoryByPersonIdAsync(int id)
        {
            var personHistories = await context.PersonHistories
               .ProjectTo<PersonHistoryDto>(mapper.ConfigurationProvider)
               .Where(x => x.PersonId == id)
               .ToListAsync();

            return personHistories;
        }
    }
}
