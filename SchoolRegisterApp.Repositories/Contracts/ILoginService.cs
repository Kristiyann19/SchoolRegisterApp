using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface ILoginService
    {
        string Login(LoginDto login);
    }
}
