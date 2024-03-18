using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public School School { get; set; }

        public string Phone { get; set; }

        public RoleEnum Role { get; set; }
    }
}
