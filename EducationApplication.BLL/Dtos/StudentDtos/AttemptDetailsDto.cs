
namespace EducationApplication.BLL.Dtos.StudentDtos
{
    public class AttemptDetailsDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Score { get; set; }
        public string StateForExam { get; set; }
        public QuizDetailsForStudentDto QuizDetailsForStudentdto { get; set; }

    }
}
