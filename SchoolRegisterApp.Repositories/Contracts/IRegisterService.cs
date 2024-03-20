using SchoolRegisterApp.Models.Dtos.UserDtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IRegisterService
    {
        void Register(RegisterDto register);

        void CheckUserNameAvailability(string username);

        void CheckPhoneAvailability(string phone);
    }
}
