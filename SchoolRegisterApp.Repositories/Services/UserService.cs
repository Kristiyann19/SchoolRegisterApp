using System.Net.Http;
using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Dtos.PersonDtos;
using SchoolRegisterApp.Models.Dtos.UserDtos;
using SchoolRegisterApp.Models.Entities;
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

        public async Task<SearchResultDto<UserDto>> GetAllUsersWithFilterAsync(UserFilterDto filter)
        {
            var users = context.Users.AsQueryable();

            if (filter != null)
            {
                users = filter.WhereBuilder(users);

            }

            var count = await users.CountAsync();

            var filteredUsers = await users
                  .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                  .Skip((filter.Page - 1) * filter.PageSize)
                  .Take(filter.PageSize)
                  .ToListAsync();

            return new SearchResultDto<UserDto>
            {
                Items = filteredUsers,
                TotalCount = count
            };
        }

        public async Task<Users> GetCurrentUser(HttpContext httpContext)
        {
            var existingUserClaim = httpContext.User
                .FindFirst(ClaimTypes.Name);

            return await context.Users
                .SingleOrDefaultAsync(u => u.Username == existingUserClaim.Value);
        }
    }
}
