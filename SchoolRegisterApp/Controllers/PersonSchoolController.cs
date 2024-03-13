﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Repositories.Contracts;

namespace SchoolRegisterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonSchoolController : BaseController
    {
        private readonly IPersonSchoolService personSchoolService;

        public PersonSchoolController(IPersonSchoolService _personSchoolService)
        {
            personSchoolService = _personSchoolService;
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPersonSchool(int id)
        {
            return Ok(await personSchoolService
                .GetPersonSchoolByPersonIdAsync(id));
        }
    }
}