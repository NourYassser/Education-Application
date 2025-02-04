using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.DAL.Data.Model
{
    public class Lecture
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Title { get; set; }
        public int Order { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Quizzes> Quizzes { get; set; } = new HashSet<Quizzes>();
        public ICollection<PdfFile> PdfFiles { get; set; } = new HashSet<PdfFile>();
        public ICollection<Video> Videos { get; set; } = new HashSet<Video>();

    }
}
