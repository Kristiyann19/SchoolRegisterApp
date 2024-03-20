using SchoolRegisterApp.Models.Dtos.PersonDtos;

namespace SchoolRegisterApp.Models.Dtos
{
    public class SearchResultDto<T>
    {
        public int TotalCount { get; set; }

        public List<T> Items { get; set; }
    }
}
