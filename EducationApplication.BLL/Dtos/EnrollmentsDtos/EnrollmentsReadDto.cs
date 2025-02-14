using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.BLL.Dtos.EnrollmentsDtos
{
    public class EnrollmentsReadDto
    {
        public bool IsDeleted { get; set; } = new bool();
        public DateTime? EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }

        [ForeignKey("Student")]
        public string? StudentId { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
    }
    public class EnrollmentsAddDto
    {
        public DateTime? EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }
    }
}
