using EducationApplication.DAL.Data.Model;

namespace EducationApplication.BLL.Dtos.InstructorDtos
{
    public class InstructorUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
