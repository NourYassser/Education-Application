namespace EducationApplication.DAL.Data.Model
{
    public class Quizzes
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }

        public int QuizDegree { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Time when the instructor Create quiz
        public DateTime ExpireDate { get; set; }                   // ExpireDate of Quiz
        public int ExamTime { get; set; }                        // quiz time
        public bool IsAvailable { get; set; } = true;

        // Soft delete
        public bool IsDeleted { get; set; } = false;

        // for Instructor  (foreign Key)
        public string InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        // for Attempt
        public virtual ICollection<Attempts> Attempts { get; set; } = new HashSet<Attempts>();

        //for Question
        public virtual ICollection<Questions> Questions { get; set; } = new HashSet<Questions>();


    }
}
