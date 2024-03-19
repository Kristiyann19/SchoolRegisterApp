using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos.UserDtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserDataAsync(HttpContext httpContext);

        Task<List<UserDto>> GetAllUsersWithFilterAsync(UserFilterDto filter);

        Task<int> GetUsersCount();
    }
}
