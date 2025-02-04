using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.DAL.Data.Model
{
    public class Video
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }

        public bool IsDeleted { get; set; }
        [ForeignKey("Lecture")]
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}
