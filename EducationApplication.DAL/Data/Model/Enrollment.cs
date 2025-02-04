using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.DAL.Data.Model
{
    public class Enrollment
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = new bool();
        public DateTime? EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }

        [ForeignKey("Student")]
        public string? StudentId { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}

public enum EnrollmentStatus
{

    Enrolled,
    Inprogress,
    Completed,
    removed
}
