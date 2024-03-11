using SchoolRegisterApp.Models.Common;
using SchoolRegisterApp.Models.Entities;
using System.Xml.Linq;

namespace SchoolRegisterApp.Models.Dtos
{
    public class UserFilterDto : IFilter<Users>
    {
        public string Username { get; set; }

        public string School { get; set; }
        public string Phone { get; set; }

        public IQueryable<Users> WhereBuilder(IQueryable<Users> query)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                query = query.Where(u => u.Username.ToLower().Contains(Username.ToLower().Trim()));
            }

            if (!string.IsNullOrEmpty(Phone))
            {
                query = query.Where(u => u.Phone.ToLower().Contains(Phone.ToLower().Trim()));
            }

            if (!string.IsNullOrEmpty(School))
            {
                query = query.Where(u => u.School.Name.ToLower().Contains(School.ToLower().Trim()));
            }

            query = query.Where(u => u.IsActive == true);

            return query;
        }
    }
}
