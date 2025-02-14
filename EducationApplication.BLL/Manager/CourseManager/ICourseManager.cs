using AutoMapper;
using EducationApplication.BLL.Dtos.CoursesDtos;
using EducationApplication.DAL.Data.Model;
using EducationApplication.DAL.Repos.CoursesRpo;

namespace EducationApplication.BLL.Manager.CourseManager
{
    public interface ICourseManager
    {
        public IEnumerable<CourseReadDto> GetAllCoursesAsync();

        public CourseReadDto GetCourseByIdAsync(int Id);

        public void AddCourseAsync(CourseAddDto dto);

        public void UpdateCourseAsync(CourseUpdateDto dto);

        public void DeleteCourseAsync(int Id);
        public void HardDeleteCourseAsync(int Id);
    }
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepo _repo;
        private readonly IMapper _mapper;

        public CourseManager(ICourseRepo rpo, IMapper mapper)
        {
            _repo = rpo;
            _mapper = mapper;
        }

        public IEnumerable<CourseReadDto> GetAllCoursesAsync()
        {
            return _mapper.Map<List<CourseReadDto>>(_repo.GetAllCourses());
        }

        public CourseReadDto GetCourseByIdAsync(int Id)
        {
            var cs = _repo.GetCourseById(Id);
            if (cs is null)
            {
                return null;
            }
            //Auto-Mapping
            return _mapper.Map<CourseReadDto>(cs);
        }

        public void AddCourseAsync(CourseAddDto dto)
        {
            var cs = _mapper.Map<Course>(dto);
            _repo.Add(cs);
            _repo.Savechange();

        }

        public void UpdateCourseAsync(CourseUpdateDto dto)
        {
            var cs = _repo.GetCourseById(dto.Id);
            //Auto-Mapping
            _mapper.Map<CourseUpdateDto>(cs);
            _repo.Savechange();
        }

        public void DeleteCourseAsync(int Id)
        {
            var cs = _repo.GetCourseById(Id);
            if (cs == null)
            {
                throw new Exception("Course not found");
            }

            cs.IsDeleted = true; // Soft delete
            _repo.Savechange();
        }
        public void HardDeleteCourseAsync(int Id)
        {
            var cs = _repo.GetCourseById(Id);
            if (cs == null)
            {
                throw new Exception("Course not found");
            }

            _repo.DeleteCourse(cs.Id);
            _repo.Savechange();
        }
    }
}
