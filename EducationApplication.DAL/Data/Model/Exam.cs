using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.DAL.Data.Model
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public int DurationMinutes { get; set; }
        public int TotalMarks { get; set; }
        public int PassingMarks { get; set; }
        public int TotalQuestions { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Questions> Questions { get; set; } = new HashSet<Questions>();
        public ICollection<ExamResult> ExamResults { get; set; } = new HashSet<ExamResult>();
    }
}
