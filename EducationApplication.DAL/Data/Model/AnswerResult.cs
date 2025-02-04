using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.DAL.Data.Model
{
    public class AnswerResult
    {
        public int Id { get; set; }
        public string StudentAnswer { get; set; }

        public bool IsDeleted { get; set; }
        public decimal MarksAwarded { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public Student Student { get; set; }

        public Questions Question { get; set; }
        public Answers Answer { get; set; }
    }
}
