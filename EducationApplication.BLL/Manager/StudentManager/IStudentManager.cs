using EducationApplication.BLL.Dtos.StudentDtos;

namespace EducationApplication.BLL.Manager.StudentManager
{
    public interface IStudentManager
    {
        public IEnumerable<StudentReadDto> GetAllStudentsAsync();

        public StudentReadDto GetStudentByIdAsync(int Id);

        public void AddStudentAsync(StudentAddDto dto);

        public void UpdateStudentAsync(StudentUpdateDto dto);

        public void DeleteStudentAsync(int Id);
        public void HardDeleteStudentAsync(int Id);
    }
}
