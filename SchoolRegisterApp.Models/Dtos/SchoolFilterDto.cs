using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos
{
    public class SchoolFilterDto
    {
        public string Name { get; set; }

        public string NameAlt { get; set; }

        public SchoolTypeEnum Type { get; set; }

        public int SettlementId { get; set; }

    }
}
