using EducationApplication.DAL.Data.Model;

namespace EducationApplication.BLL.Dtos.StudentDtos
{
    public class StudentReadDto
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public string Email { get; set; }
        public string Grade { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }


    }
}
