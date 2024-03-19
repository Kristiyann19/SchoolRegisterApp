﻿using Microsoft.AspNetCore.Http;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;

namespace SchoolRegisterApp.Repositories.Contracts
{
    public interface ISchoolService
    {
        Task<List<SchoolDto>> GetAllSchoolsWithFilterAsync(SchoolFilterDto schoolFilter);

        Task AddSchoolAsync(HttpContext httpContext, AddSchoolDto school);

        Task<int> GetSchoolsCount();

        Task<List<SchoolDto>> GetAllSchools();
    }
}
