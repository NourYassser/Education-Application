using EducationApplication.DAL.Data.DbHelper;
using EducationApplication.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EducationApplication.DAL.Repos.InstructorRpo
{
    public class InstructorRpo : IinstructorRpo
    {
        private readonly EducationDbContext _context;

        public InstructorRpo(EducationDbContext context)
        {
            _context = context;
        }

        public List<Instructor> GetAllInstructors()
        {
            return _context.Instructors.AsNoTracking().ToList();
        }
        public Instructor GetInstructorById(int id)
        {
            return _context.Instructors.FirstOrDefault(x => x.Id == id.ToString());
        }

        public void Add(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            Savechange();
        }
        public void UpdateInstructor(int Id)
        {
            _context.Instructors.Update(_context.Instructors.FirstOrDefault(x => x.Id == Id.ToString()));
            Savechange();
        }
        public void DeleteInstructor(int Id)
        {
            _context.Instructors.Remove(_context.Instructors.FirstOrDefault(x => x.Id == Id.ToString()));
            Savechange();
        }

        public void Savechange()
        {
            _context.SaveChanges();
        }

    }
}
