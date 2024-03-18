using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos.PersonSchoolDtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IPersonSchoolService
    {
        Task<List<PersonSchoolDto>> GetPersonSchoolByPersonIdAsync(int id);

        Task AddPersonSchoolAsync(PersonSchoolAddDto personSchoolAddDto, HttpContext httpContext);

        Task UpdatePersonSchoolAsync(PersonSchoolUpdateDto personSchoolUpdateDto, HttpContext httpContext);
    }
}
