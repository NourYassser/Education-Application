using EducationApplication.DAL.Data.DbHelper;
using EducationApplication.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EducationApplication.DAL.Repos.StudentRpo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly EducationDbContext _context;

        public StudentRepo(EducationDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.AsNoTracking().ToList();
        }
        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id.ToString());
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            Savechange();
        }
        public void UpdateStudent(int Id)
        {
            _context.Students.Update(_context.Students.FirstOrDefault(x => x.Id == Id.ToString()));
            Savechange();
        }
        public void Delete(int Id)
        {
            _context.Students.Remove(_context.Students.FirstOrDefault(x => x.Id == Id.ToString()));
            Savechange();
        }

        public void Savechange()
        {
            _context.SaveChanges();
        }

    }
}
