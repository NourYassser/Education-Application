using EducationApplication.DAL.Data.DbHelper;
using EducationApplication.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EducationApplication.DAL.Repos.EnrollmentRpo
{
    public interface IEnrollmentRepo
    {
        public List<Enrollment> GetAllEnrollments();
        public Enrollment GetEnrollmentById(int id);
        public void Add(Enrollment enrollment);
        public void DeleteEnrollment(int Id);
        public void Savechange();
    }
    public class EnrollmentRepo : IEnrollmentRepo
    {
        private readonly EducationDbContext _context;

        public EnrollmentRepo(EducationDbContext context)
        {
            _context = context;
        }

        public List<Enrollment> GetAllEnrollments()
        {
            return _context.Enrollments.AsNoTracking().ToList();
        }
        public Enrollment GetEnrollmentById(int id)
        {
            return _context.Enrollments.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            Savechange();
        }
        public void DeleteEnrollment(int Id)
        {
            _context.Enrollments.Remove(_context.Enrollments.FirstOrDefault(x => x.Id == Id));
            Savechange();
        }

        public void Savechange()
        {
            _context.SaveChanges();
        }
    }
}
