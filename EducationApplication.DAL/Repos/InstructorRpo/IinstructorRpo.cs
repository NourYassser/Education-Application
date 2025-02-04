using EducationApplication.DAL.Data.Model;

namespace EducationApplication.DAL.Repos.InstructorRpo
{
    public interface IinstructorRpo
    {
        public List<Instructor> GetAllInstructors();
        public Instructor GetInstructorById(int id);
        public void Add(Instructor instructor);
        public void UpdateInstructor(int Id);
        public void DeleteInstructor(int Id);
        public void Savechange();
    }
}
