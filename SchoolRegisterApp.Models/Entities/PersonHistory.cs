namespace SchoolRegisterApp.Models.Entities
{
    public class PersonHistory
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int UserId { get; set; }

        //public User User { get; set; }

        public DateTime ActionDate { get; set; }

        // public DataModified DataModified { get; set; }

        //public ModificationType ModificationType { get; set; }
    }
}
