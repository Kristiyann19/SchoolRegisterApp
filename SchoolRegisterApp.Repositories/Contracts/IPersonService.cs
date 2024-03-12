using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllPeopleAsync();

        Task<List<PersonDto>> GetFilteredPeopleAsync(PersonFilterDto filter);

<<<<<<< HEAD
        Task<PersonDetailsDto> GetPersonDetailsAsync(int id);

        Task UpdatePersonAsync(int id, PersonDetailsDto updatedPerson);
=======
        Task AddPersonAsync(PersonAddDto personAddDto, HttpContext htppContext);
>>>>>>> 4ede17321f1a302f9e3a1a52a445dcf64322833c
    }
}
