using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models;
using SchoolRegisterApp.Repositories.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            var LoginUser = context.Users.SingleOrDefault(x => x.Username == login.UserName);

            if (LoginUser == null)
            {
                return string.Empty;
            }

            var passwordHash = PasswordHasher.ComputeHash(login.Password, LoginUser.PasswordSalt);

            if (LoginUser.PasswordHash != passwordHash)
            {
                throw new Exception("Username or password did not match.");
            }


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "http://localhost:12123",
                Audience = "http://localhost:12123",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }
    }
}
