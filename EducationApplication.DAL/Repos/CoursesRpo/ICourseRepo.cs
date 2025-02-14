using EducationApplication.DAL.Data.Model;

namespace EducationApplication.DAL.Repos.CoursesRpo
{
    public interface ICourseRepo
    {
        public List<Course> GetAllCourses();
        public Course GetCourseById(int id);
        public void Add(Course course);
        public void UpdateCourse(int Id);
        public void DeleteCourse(int Id);
        public void Savechange();
    }
}
