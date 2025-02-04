using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApplication.DAL.Data.Model
{
    public class PdfFile
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        [ForeignKey("Lecture")]
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}
