using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IPersonSchoolService
    {
        Task<List<PersonSchoolDto>> GetPersonSchoolByPersonIdAsync(int id);
    }
}
