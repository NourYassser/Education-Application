﻿namespace EducationApplication.DAL.Data.Model
{
    public class Attempts
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Score { get; set; }
        public string StateForExam { get; set; } = "Not Joined";


        // For Quiz
        public int QuizId { get; set; }
        public virtual Quizzes Quiz { get; set; }

        //For Student
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }


        //For Answers
        public virtual ICollection<Answers> Answers { get; set; } = new HashSet<Answers>();
    }
}
