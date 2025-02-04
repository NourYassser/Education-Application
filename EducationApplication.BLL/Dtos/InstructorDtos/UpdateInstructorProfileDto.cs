using EducationApplication.DAL.Data.Model;

namespace EducationApplication.BLL.Dtos.InstructorDtos
{
    public class UpdateInstructorProfileDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string ImgUrl { get; set; }

        public string PhoneNumber { get; set; }

        public GenderType Gender { get; set; }

    }
}
