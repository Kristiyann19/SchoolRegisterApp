using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos.SchoolDtos
{
    public class SchoolDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameAlt { get; set; }

        public SchoolTypeEnum Type { get; set; }

        public Settlement Settlement { get; set; }

        public int SettlementId { get; set; }

        public bool IsActive { get; set; }
    }
}
