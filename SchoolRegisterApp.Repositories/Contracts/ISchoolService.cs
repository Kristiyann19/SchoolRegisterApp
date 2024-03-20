using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface ISchoolService
    {
        Task<SearchResultDto<SchoolDto>> GetAllSchoolsWithFilterAsync(SchoolFilterDto schoolFilter);

        Task AddSchoolAsync(HttpContext httpContext, AddSchoolDto school);

        Task<List<SchoolDto>> GetAllSchools();
    }
}
