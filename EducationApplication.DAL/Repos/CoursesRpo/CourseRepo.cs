using EducationApplication.DAL.Data.DbHelper;
using EducationApplication.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EducationApplication.DAL.Repos.CoursesRpo
{
    public class CourseRepo : ICourseRepo
    {
        private readonly EducationDbContext _context;

        public CourseRepo(EducationDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.AsNoTracking().ToList();
        }
        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
            Savechange();
        }
        public void UpdateCourse(int Id)
        {
            _context.Courses.Update(_context.Courses.FirstOrDefault(x => x.Id == Id));
            Savechange();
        }
        public void DeleteCourse(int Id)
        {
            _context.Courses.Remove(_context.Courses.FirstOrDefault(x => x.Id == Id));
            Savechange();
        }

        public void Savechange()
        {
            _context.SaveChanges();
        }

    }
}
