using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserDataAsync(HttpContext httpContext);

        Task<List<UserDto>> GetAllUsersAsync();
    }
}
