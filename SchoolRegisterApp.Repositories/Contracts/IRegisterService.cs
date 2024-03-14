using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IRegisterService
    {
        void Register(RegisterDto register);

        bool CheckUserNameAvailability(string username);

        bool CheckPhoneAvailability(string phone);
    }
}
