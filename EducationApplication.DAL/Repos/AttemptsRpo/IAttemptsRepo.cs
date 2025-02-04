
using EducationApplication.DAL.Data.Model;
namespace EducationApplication.DAL.Repos.AttemptsRpo
{
    public interface IAttemptsRepo
    {
        void StartQuizAttempt(Attempts attempt);
        void SubmitQuizAttempt(int attemptId, List<Answers> submittedAnswers);
        Attempts GetResults(int attemptId);
        IEnumerable<Attempts> GetUserAttempts(string studentId);
        Student GetStudentById(string studID);
        Quizzes GetQuizById(int quizId);
        IEnumerable<Questions> questions(int quizId);
        IEnumerable<Attempts> GetAttemptsByStudentId(string studentId);
        void SaveChanges();
        public int TotalAnswers(int attemptId);
        public int CorrectAnswers(int attemptId);
        public int WrongAnsers(int attemptId);
        public string GetGrade(int totalScore);
    }
}
