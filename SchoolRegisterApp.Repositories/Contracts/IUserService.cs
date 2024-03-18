using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos.UserDtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserDataAsync(HttpContext httpContext);

        Task<IEnumerable<UserDto>> GetAllUsersWithFilterAsync(UserFilterDto filter);

        Task<int> GetUsersCount();
    }
}
