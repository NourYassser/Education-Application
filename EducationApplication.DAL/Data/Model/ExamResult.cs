using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.DAL.Data.Model
{
    public class ExamResult
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public decimal TotalMarks { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsPassed { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Student")]

        public string StudentId { get; set; }

        public Exam Exam { get; set; }
        public Student student { get; set; }
    }
}
