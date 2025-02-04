using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.DAL.Data.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int TotalHours { get; set; }

        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }

        public Instructor Instructor { get; set; }
        public ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<Quizzes> Quizzes { get; set; } = new HashSet<Quizzes>();
        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
        public ICollection<Questions> Questions { get; set; } = new HashSet<Questions>();
    }
}
