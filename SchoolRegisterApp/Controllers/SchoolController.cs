﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : BaseController
    {
        private readonly ISchoolService schoolService;

        public SchoolController(ISchoolService _schoolService)
        {
            schoolService = _schoolService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSchools()
        {
            return Ok(await schoolService
                .GetAllSchoolsAsync());
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetFilteredSchools([FromQuery] SchoolFilterDto schoolFilter)
        {
            return Ok(await schoolService
                .GetFilteredSchoolsAsync(schoolFilter));
        }

        [HttpPost]
        public async Task<IActionResult> AddSchool([FromBody] AddSchoolDto school)
        {
            await schoolService.AddSchoolAsync(HttpContext, school);

            return Ok();
        }

        [HttpGet("GetSchoolByUser")]
        public async Task<IActionResult> GetSchoolByUser()
        {
            return Ok(await schoolService
                .GetSchoolByUserAsync(HttpContext));
        }

        [HttpGet("GetSchoolByPerson/{personId:int}")]
        public async Task<IActionResult> GetSchoolByPerson(int personId)
        {
            return Ok(await schoolService
                .GetSchoolByPersonAsync(personId));
        }
    }
}
