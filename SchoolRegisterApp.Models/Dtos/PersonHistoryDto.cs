using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos
{
    public class PersonHistoryDto
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int UserId { get; set; }

        public DateTime ActionDate { get; set; }

        public DataModified DataModified { get; set; }

        public ModificationType ModificationType { get; set; }
    }
}
