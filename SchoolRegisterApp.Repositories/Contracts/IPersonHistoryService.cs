using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IPersonHistoryService
    {
        Task<List<PersonHistoryDto>> GetPersonHistoryByPersonIdAsync (int id);
    }
}
