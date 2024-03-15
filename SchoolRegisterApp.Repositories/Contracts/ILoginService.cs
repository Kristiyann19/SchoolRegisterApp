using SchoolRegisterApp.Models.Dtos.UserDtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface ILoginService
    {
        string Login(LoginDto login);
    }
}
