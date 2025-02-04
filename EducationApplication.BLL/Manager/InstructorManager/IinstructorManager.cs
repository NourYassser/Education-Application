using EducationApplication.BLL.Dtos.InstructorDtos;

namespace EducationApplication.BLL.Manager.InstructorManager
{
    public interface IinstructorManager
    {
        public IEnumerable<InstructorReadDto> GetAllInstructorsAsync();

        public InstructorReadDto GetInstructorByIdAsync(int Id);

        public void AddInstructorAsync(InstructorAddDto dto);

        public void UpdateInstructorAsync(InstructorUpdateDto dto);

        public void DeleteInstructorAsync(int Id);
        public void HardDeleteInstructorAsync(int Id);
    }
}
