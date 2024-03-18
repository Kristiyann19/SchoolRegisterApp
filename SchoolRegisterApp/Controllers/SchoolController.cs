﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Attributes;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;
using SchoolRegisterApp.Models.Enums;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Repositories.Services;

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
        [AllowAnonymous]
        public async Task<IActionResult> GetAllSchools([FromQuery] SchoolFilterDto filter)
        {
            return Ok(await schoolService
                .GetAllSchoolsWithFilterAsync(filter));
        }

        [HttpGet]
        [Route("Count")]
        public async Task<IActionResult> TotalSchools()
        {
            return Ok(await schoolService
                .GetSchoolsCount());
        }


        [HttpPost]
        [AuthorizedUser(RoleEnum.Admin)]
        public async Task<IActionResult> AddSchool([FromBody] AddSchoolDto school)
        {
            await schoolService.AddSchoolAsync(HttpContext, school);

            return Ok();
        }
    }
}
