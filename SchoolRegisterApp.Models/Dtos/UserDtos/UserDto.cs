using SchoolRegisterApp.Models.Entities;

namespace SchoolRegisterApp.Models.Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public School School { get; set; }

        public string Phone { get; set; }
    }
}
