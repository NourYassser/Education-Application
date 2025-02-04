using EducationApplication.DAL.Data.Model;

namespace EducationApplication.BLL.Dtos.InstructorDtos
{
    public class InstructorReadDto
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public GenderType Gender { get; set; }
    }
}
