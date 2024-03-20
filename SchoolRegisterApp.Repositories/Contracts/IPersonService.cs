using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos;
using SchoolRegisterApp.Models.Dtos.PersonDtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IPersonService
    {
        Task<SearchResultDto<PersonDto>> GetAllPeopleWithFilterAsync(HttpContext httpContext, PersonFilterDto filter);

        Task<PersonDetailsDto> GetPersonDetailsAsync(int id);

        Task UpdatePersonAsync(int id, PersonDetailsDto updatedPerson, HttpContext httpContext);

        Task AddPersonAsync(PersonDetailsDto personAddDto, HttpContext htppContext);

    }
}
