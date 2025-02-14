﻿namespace EducationApplication.BLL.Dtos.StudentDtos
{
    public class QuizDetailsForStudentDto
    {
        public int Id { get; set; }
        public string tittle { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int QuizDegree { get; set; }
        public int ExamTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
