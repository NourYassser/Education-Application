using EducationApplication.DAL.Data.DbHelper;
using EducationApplication.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EducationApplication.DAL.Repos.AttemptsRpo
{
    public class AttemptsRepo : IAttemptsRepo
    {
        private readonly EducationDbContext _context;

        public AttemptsRepo(EducationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Attempts> GetAll()
        {
            return _context.Attempts;
        }

        public IEnumerable<Attempts> GetAttemptsByStudentId(string studentId)
        {
            return _context.Attempts
                            .Where(a => a.StudentId == studentId)
                             .Include(a => a.Quiz)
                                .ToList();
        }

        public Attempts GetById(int id)
        {
            Attempts? attempts = _context.Attempts.FirstOrDefault(a => a.Id == id);
            return attempts!;
        }

        public string GetGrade(int totalScore)
        {
            if (totalScore < 50)
            {
                return "Failed";
            }
            else if (totalScore >= 50 && totalScore < 65)
            {
                return "Fair";
            }
            else if (totalScore >= 65 && totalScore < 75)
            {
                return "Good";
            }
            else if (totalScore >= 75 && totalScore < 85)
            {
                return "Very Good";
            }
            else
            {
                return "Excellent";
            }
        }

        public Quizzes GetQuizById(int quizId)
        {
            Quizzes? quizzes = _context.Quizzes.FirstOrDefault(q => q.Id == quizId);
            return quizzes!;
        }

        public Attempts GetResults(int attemptId)
        {
            Attempts? attempt = _context.Attempts.FirstOrDefault(a => a.Id == attemptId);

            if (attempt == null)
                throw new Exception("Attempt not found");

            return attempt!;
        }

        public Student GetStudentById(string studID)
        {
            Student? student = _context.Users.OfType<Student>().FirstOrDefault(s => s.Id == studID);
            return student!;
        }

        public IEnumerable<Attempts> GetUserAttempts(string studentId)
        {
            IEnumerable<Attempts> attempts = _context.Attempts.Where(a => a.StudentId == studentId).ToList();
            if (attempts != null)
            {
                return attempts;
            }
            else
            {
                throw new Exception("Attempt not found");
            }
        }
        public void Add(Attempts entity)
        {

        }

        public int CorrectAnswers(int attemptId)
        {
            int correctAnswers = _context.Answers
                                          .Where(a => a.AttemptId == attemptId && a.IsCorrect)
                                           .Count();
            return correctAnswers;
        }

        public void DeleteById(int id)
        {
            Attempts? attempts = _context.Attempts.FirstOrDefault(a => a.Id == id);
            if (attempts != null)
            {
                _context.Attempts.Remove(attempts!);
                _context.SaveChanges();
            }
            throw new Exception("Not Found");
        }


        public IEnumerable<Questions> questions(int quizId)
        {
            return _context.Questions
                            .Where(q => q.QuizId == quizId)
                             .Include(q => q.Options)
                              .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void StartQuizAttempt(Attempts attempt)
        {
            _context.Attempts.Add(attempt);
            _context.SaveChanges();
        }

        public void SubmitQuizAttempt(int attemptId, List<Answers> submittedAnswers)
        {
            Attempts? attempt = _context.Attempts.FirstOrDefault(a => a.Id == attemptId);


            if (attempt == null && attempt!.EndTime > DateTime.Now)
                throw new Exception("Attempt not found");

            foreach (Answers answer in submittedAnswers)
            {

                Answers answers = new Answers
                {
                    AttemptId = attemptId,
                    QuestionId = answer.QuestionId,
                    SubmittedAnswer = answer.SubmittedAnswer,
                    IsCorrect = _context.Questions.FirstOrDefault(q => q.Id == answer.QuestionId)
                    ?.CorrectAnswer == answer.SubmittedAnswer
                };


                if (answers.IsCorrect == true)
                {
                    attempt.Score = attempt.Score + 1;
                }
                _context.Answers.Add(answers);
            }


            attempt.EndTime = DateTime.Now;
            _context.SaveChanges();
        }

        public int TotalAnswers(int attemptId)
        {
            int totalQuestions = _context.Answers
                                            .Where(a => a.AttemptId == attemptId)
                                                .Count();
            return totalQuestions;
        }

        public void Update(Attempts entity)
        {
            _context.SaveChanges();
        }

        public int WrongAnsers(int attemptId)
        {
            int wronganswers = _context.Answers
                                          .Where(a => a.AttemptId == attemptId && !a.IsCorrect)
                                             .Count();
            return wronganswers;
        }
    }
}
