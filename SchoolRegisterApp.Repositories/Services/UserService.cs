using System.Security.Claims;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos.UserDtos;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Repositories.Services
{
    public class UserService : IUserService
    {
        private readonly SchoolRegisterDbContext context;
        private readonly IMapper mapper;

        public UserService(SchoolRegisterDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;

        }

        public async Task<UserDto> GetUserDataAsync(HttpContext httpContext)
        {
            var existingUserClaim = httpContext.User
                .FindFirst(ClaimTypes.Name);

            if (existingUserClaim != null)
            {
                var userName = existingUserClaim.Value;
                var existingUser = await context.Users
                .Where(u => u.Username == userName)
                    .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                return existingUser;
            }

            return null;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await context.Users
                .Include(u => u.School)
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return users;
        }

        public async Task<List<UserDto>> GetFilteredUsersAsync(UserFilterDto filter)
        {
            var users = await filter
               .WhereBuilder(context.Users.Include(u => u.School).AsQueryable())
               .ProjectTo<UserDto>(mapper.ConfigurationProvider)
               .ToListAsync();

            return users;
        }
    }
}
