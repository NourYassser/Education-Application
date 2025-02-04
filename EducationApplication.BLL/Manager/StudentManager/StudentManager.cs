using AutoMapper;
using EducationApplication.BLL.Dtos.StudentDtos;
using EducationApplication.DAL.Data.Model;
using EducationApplication.DAL.Repos.StudentRpo;

namespace EducationApplication.BLL.Manager.StudentManager
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepo _repo;
        private readonly IMapper _mapper;

        public StudentManager(IStudentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<StudentReadDto> GetAllStudentsAsync()
        {
            return _mapper.Map<List<StudentReadDto>>(_repo.GetAllStudents());
        }

        public StudentReadDto GetStudentByIdAsync(int Id)
        {
            var stu = _repo.GetStudentById(Id);
            if (stu is null)
            {
                return null;
            }
            //Auto-Mapping
            return _mapper.Map<StudentReadDto>(stu);
        }

        public void AddStudentAsync(StudentAddDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            student.UserType = TypeUser.Student;
            _repo.Add(student);
            _repo.Savechange();

        }

        public void UpdateStudentAsync(StudentUpdateDto dto)
        {
            var stu = _repo.GetStudentById(dto.Id);
            //Auto-Mapping
            _mapper.Map<StudentUpdateDto>(stu);
            _repo.Savechange();
        }

        public void DeleteStudentAsync(int Id)
        {
            var student = _repo.GetStudentById(Id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            student.IsDeleted = true; // Soft delete
            _repo.Savechange();
        }
        public void HardDeleteStudentAsync(int Id)
        {
            var student = _repo.GetStudentById(Id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            _repo.Delete(int.Parse(student.Id));
            _repo.Savechange();
        }
    }
}
