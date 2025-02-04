namespace EducationApplication.DAL.Data.Model
{
    public class Answers
    {
        public int Id { get; set; }
        public string SubmittedAnswer { get; set; }
        public bool IsCorrect { get; set; }

        // for Attempt
        public int AttemptId { get; set; }
        public virtual Attempts Attempt { get; set; }


        // for Question
        public int QuestionId { get; set; }
        public virtual Questions Question { get; set; }
    }
}
