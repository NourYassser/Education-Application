﻿using EducationApplication.DAL.Data.Model;

namespace EducationApplication.BLL.Dtos.StudentDtos
{
    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }
        public GenderType Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
