using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface ISettlementService
    {
        Task<List<SettlementDto>> GetAllSettlementsAsync();
    }
}
