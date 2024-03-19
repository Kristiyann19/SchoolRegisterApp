using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Repositories.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SchoolRegisterApp.Models.Dtos.UserDtos;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Repositories.CustomExceptions;
using SchoolRegisterApp.Repositories.CustomExceptionMessages;

namespace SchoolRegisterApp.Repositories.Services
{
    public class LoginService : ILoginService
    {
        private readonly SchoolRegisterDbContext context;
        private readonly IConfiguration configuration;

        public LoginService(SchoolRegisterDbContext _context, IConfiguration _configuration)
        {
            context = _context;
            configuration = _configuration;
        }


        public string Login(LoginDto login)
        {
            var LoginUser = context.Users.SingleOrDefault(x => x.Username == login.Username);

            if (LoginUser == null)
            {
                return string.Empty;
            }

            var passwordHash = PasswordHasher.ComputeHash(login.Password, LoginUser.PasswordSalt);

            if (LoginUser.PasswordHash != passwordHash)
            {
                throw new NotFoundException(ExceptionMessages.LoginInvalidUsernameOrPassword);
            }

            return GenerateToken(LoginUser);
        }

        private string GenerateToken(Users loggedInUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loggedInUser.Username),
                    new Claim(ClaimTypes.Role, loggedInUser.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("Jwt:ExpiresInMinutes")),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }
    }
}
