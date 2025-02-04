using EducationApplication.DAL.Data.Model;

namespace EducationApplication.DAL.Repos.StudentRpo
{
    public interface IStudentRepo
    {

        public List<Student> GetAllStudents();
        public Student GetStudentById(int id);
        public void Add(Student student);
        public void UpdateStudent(int Id);
        public void Delete(int Id);
        public void Savechange();


    }
}
