using SchoolRegisterApp.Models.Common;
using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos.PersonDtos
{
    public class PersonFilterDto : IFilter<Person>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Uic { get; set; }

        public GenderEnum? Gender { get; set; }

        public string BirthPlace { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 3;
        //int page, int pageSize

        public IQueryable<Person> WhereBuilder(IQueryable<Person> query)
        {
            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(FirstName.ToLower().Trim()));
            }

            if (!string.IsNullOrWhiteSpace(LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(LastName.ToLower().Trim()));
            }

            if (!string.IsNullOrWhiteSpace(Uic))
            {
                query = query.Where(x => x.Uic.ToLower().Contains(Uic.ToLower().Trim()));
            }

            if (Gender.HasValue)
            {
                query = query.Where(p => p.Gender == Gender);
            }

            if (!string.IsNullOrWhiteSpace(BirthPlace))
            {
                query = query.Where(x => x.BirthPlace.Name.ToLower().Contains(BirthPlace.ToLower().Trim()));
            }

  

            return query;
        }
    }


}
