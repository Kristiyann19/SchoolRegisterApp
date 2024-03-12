﻿using SchoolRegisterApp.Models.Entities;

namespace SchoolRegisterApp.Models.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Uic { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }
    }
}