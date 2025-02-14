using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.BLL.Dtos.CoursesDtos
{
    public class CourseReadDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalHours { get; set; }
    }
    public class CourseUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int TotalHours { get; set; }

        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }
    }
    public class CourseAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalHours { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }
    }
}
