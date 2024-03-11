using SchoolRegisterApp.Models.Common;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos
{
    public class SchoolFilterDto : IFilter<School>
    {
        public string Name { get; set; }

        public string NameAlt { get; set; }

        public SchoolTypeEnum Type { get; set; }

        public string Settlement { get; set; }

        public IQueryable<School> WhereBuilder(IQueryable<School> query)
        {
            throw new NotImplementedException();
        }
    }
}
