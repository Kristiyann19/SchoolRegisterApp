﻿using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync();

        Task<IEnumerable<SchoolDto>> GetFilteredSchoolsAsync(SchoolFilterDto schoolFilter);

        Task<SchoolIdAndNameDto> GetSchoolByUserAsync(HttpContext httpContext);

        Task<SchoolIdAndNameDto> GetSchoolByPersonAsync(int personId);
    }
}
