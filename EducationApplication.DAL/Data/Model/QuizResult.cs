using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.DAL.Data.Model
{
    public class QuizResult
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public decimal Score { get; set; }
        public decimal TotalMarks { get; set; }
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }

        [ForeignKey("Student")]

        public string StudentId { get; set; }

        public Student student { get; set; }

        public Quizzes Quiz { get; set; }
    }
}
