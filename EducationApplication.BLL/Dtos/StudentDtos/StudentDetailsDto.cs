using EducationApplication.DAL.Data.Model;

namespace EducationApplication.BLL.Dtos.StudentDtos
{
    public class StudentDetailsDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; } = 0;
        public GenderType Gender { get; set; }
        public TypeUser UserType { get; set; }
        public string Adress { get; set; }
        public string Grade { get; set; } = "Add the Grade";
        public List<AttemptDetailsDto> AttemptDetailsDtos { get; set; } = new List<AttemptDetailsDto>();


    }
}
