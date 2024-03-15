namespace SchoolRegisterApp.Models.Dtos.UserDtos
{
    public class RegisterDto
    {
        public string Username { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;

        public int SchoolId { get; set; }
    }
}
