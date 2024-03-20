using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Dtos.UserDtos;
using SchoolRegisterApp.Models.Entities;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserDataAsync(HttpContext httpContext);

        Task<SearchResultDto<UserDto>> GetAllUsersWithFilterAsync(UserFilterDto filter);

        Task<Users> GetCurrentUser(HttpContext httpContext);
    }
}
