using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos.SchoolDtos
{
    public class AddSchoolDto
    {
        public string Name { get; set; }

        public string NameAlt { get; set; }

        public SchoolTypeEnum Type { get; set; }

        public int SettlementId { get; set; }

        public Settlement Settlement { get; set; }

        public bool IsActive { get; set; }
    }
}
