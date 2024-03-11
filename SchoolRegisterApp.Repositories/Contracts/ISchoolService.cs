using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync();

        Task<IEnumerable<SchoolDto>> 
    }
}
