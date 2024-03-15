using SchoolRegisterApp.Models.Dtos.PersonHistoryDtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IPersonHistoryService
    {
        Task<List<PersonHistoryDto>> GetPersonHistoryByPersonIdAsync (int id);
    }
}
