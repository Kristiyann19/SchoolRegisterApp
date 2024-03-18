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


        public async Task<IEnumerable<UserDto>> GetAllUsersWithFilterAsync(UserFilterDto filter)
        {
            var users = context.Users.AsQueryable();

            if (filter != null)
            {
                users = filter.WhereBuilder(users);

            }

            var filteredUsers = await users
                  .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                  .Skip((filter.Page - 1) * filter.PageSize)
                  .Take(filter.PageSize)
                  .ToListAsync();

            return filteredUsers;
        }

        public async Task<int> GetUsersCount()
           => await context.Users.CountAsync();
    }
}
