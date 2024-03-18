using SchoolRegisterApp.Models.Common;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos.SchoolDtos
{
    public class SchoolFilterDto : IFilter<School>
    {
        public string Name { get; set; }

        public string NameAlt { get; set; }

        public SchoolTypeEnum? Type { get; set; }

        public string Settlement { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 5;


        public IQueryable<School> WhereBuilder(IQueryable<School> query)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(Name.ToLower().Trim()));
            }

            if (!string.IsNullOrWhiteSpace(NameAlt))
            {
                query = query.Where(x => x.NameAlt.ToLower().Contains(NameAlt.ToLower().Trim()));
            }

            if (Type.HasValue)
            {
                query = query.Where(p => p.Type == Type);
            }

            query = query.Where(x => x.IsActive == true);

            return query;
        }
    }
}
