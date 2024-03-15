using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Repositories.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly SchoolRegisterDbContext context;

        public RegisterService(SchoolRegisterDbContext _context)
        {
            context = _context;
        }


        public bool CheckUserNameAvailability(string username)
             => !context.Users.Any(u => u.Username == username);

        public bool CheckPhoneAvailability(string phone)
                => !context.Users.Any(u => u.Phone == phone);

        public void Register(RegisterDto register)
        {
            var isUsernameAvailable = CheckUserNameAvailability(register.Username);
            var isPhoneAvailable = CheckPhoneAvailability(register.Phone);


            if (!isUsernameAvailable)
            {
                throw new Exception("Username is already used");
            }

            if (!isPhoneAvailable)
            {
                throw new Exception("Phone is already used");
            }

            var user = new Users
            {
                Username = register.Username,
                Phone = register.Phone,
                PasswordSalt = PasswordHasher.GenerateSalt(),
                SchoolId = register.SchoolId == 0 ? null : register.SchoolId
            };
            user.PasswordHash = PasswordHasher.ComputeHash(register.Password, user.PasswordSalt);
            user.IsActive = true;

            context.Users.Add(user);
            context.SaveChanges();
        }

        
    }
}

