using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllPeopleAsync();

        Task<List<PersonDto>> GetFilteredPeopleAsync(PersonFilterDto filter);
    }
}
