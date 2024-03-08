namespace SchoolRegisterApp.Models.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Phone { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public int SchoolId { get; set; }

        //public School School { get; set; }

        public bool IsActive { get; set; }
    }
}
