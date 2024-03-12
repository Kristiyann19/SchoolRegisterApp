using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Repositories.Services
{
    public class SettlementService : ISettlementService
    {
        private readonly SchoolRegisterDbContext context;
        private readonly IMapper mapper;

        public SettlementService(SchoolRegisterDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<SettlementDto>> GetAllSettlementsAsync()
            => await context.Settlements
               .ProjectTo<SettlementDto>(mapper.ConfigurationProvider)
               .ToListAsync();
    }
}
