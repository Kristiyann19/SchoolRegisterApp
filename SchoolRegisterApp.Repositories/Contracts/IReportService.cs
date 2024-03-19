using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IReportService
    {
        Task<List<ReportDto>> GetPersonCountGroupedBySchooAndPosition();
    }
}
