using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Models.Dtos.UserDtos;
using SchoolRegisterApp.Models.Enums;
using SchoolRegisterApp.Repositories.CustomExceptions;
using SchoolRegisterApp.Repositories.CustomExceptionMessages;

namespace SchoolRegisterApp.Repositories.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly SchoolRegisterDbContext context;

        public RegisterService(SchoolRegisterDbContext _context)
        {
            context = _context;
        }


        public void CheckUserNameAvailability(string username)
        {
            var userNameExists = context.Users.Any(u => u.Username == username);

            if (userNameExists)
            {
                throw new BadRequestException(ExceptionMessages.AlreadyUsedUsername);
            }
        }

        public void CheckPhoneAvailability(string phone)
        {
            var phoneExists = context.Users.Any(u => u.Phone == phone);

            if (phoneExists)
            {
                throw new BadRequestException(ExceptionMessages.AlreadyUsedPhone);
            }
        }

        public void Register(RegisterDto register)
        {
            CheckUserNameAvailability(register.Username);
            CheckPhoneAvailability(register.Phone);

            var user = new Users
            {
                Username = register.Username,
                Phone = register.Phone,
                PasswordSalt = PasswordHasher.GenerateSalt(),
                SchoolId = register.SchoolId == 0 ? null : register.SchoolId
            };
            user.PasswordHash = PasswordHasher.ComputeHash(register.Password, user.PasswordSalt);
            user.IsActive = true;
            user.Role = RoleEnum.Director;

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}

