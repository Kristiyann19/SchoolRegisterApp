using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Models.Entities;

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

        public async Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync()
            => await context.Schools
               .ProjectTo<SchoolDto>(mapper.ConfigurationProvider)
               .ToListAsync();
        

        public Task<IEnumerable<SchoolDto>> GetFilteredSchoolsAsync(SchoolFilterDto schoolFilter)
        {
            IQueryable<SchoolDto> query = context.Schools
               .ProjectTo<SchoolDto>(mapper.ConfigurationProvider);


        }
    }
}
