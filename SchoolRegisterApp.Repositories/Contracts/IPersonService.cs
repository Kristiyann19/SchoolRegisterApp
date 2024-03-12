using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllPeopleAsync();

        Task<List<PersonDto>> GetFilteredPeopleAsync(PersonFilterDto filter);

        Task AddPersonAsync(PersonAddDto personAddDto, HttpContext htppContext);
    }
}
