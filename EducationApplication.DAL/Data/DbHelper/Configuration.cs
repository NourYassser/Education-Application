//using EducationApplication.DAL.Data.Model;
//using Microsoft.EntityFrameworkCore;

//namespace EducationApplication.DAL.Data.DbHelper
//{
//    public class Configuration
//    {
//        public void Configure(ModelBuilder modelBuilder)
//        {

//            modelBuilder.Entity<AnswerResult>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<Questions>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<Enrollment>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<Course>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<QuizResult>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<Lecture>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<Video>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<PdfFile>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<ExamResult>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<Quizzes>()
//                        .HasQueryFilter(a => !a.IsDeleted);

//            modelBuilder.Entity<Exam>()
//                        .HasQueryFilter(a => !a.IsDeleted);



//            /*modelBuilder.Entity<Enrollment>()
//                        .HasIndex(e => new { e.StudentId, e.CourseId })
//                        .IsUnique();*/

//            modelBuilder.Entity<Enrollment>()
//                        .HasOne(e => e.Course)
//                        .WithMany()
//                        .HasForeignKey(e => e.CourseId)
//                        .OnDelete(DeleteBehavior.NoAction); // Change to NO ACTION

//            modelBuilder.Entity<Enrollment>()
//                        .HasOne(e => e.Student)
//                        .WithMany()
//                        .HasForeignKey(e => e.StudentId)
//                        .OnDelete(DeleteBehavior.Cascade);

//            modelBuilder.Entity<QuizResult>()
//                        .HasIndex(e => new { e.StudentId, e.QuizId })
//                        .IsUnique();

//            modelBuilder.Entity<ExamResult>()
//                        .HasIndex(e => new { e.StudentId, e.ExamId })
//                        .IsUnique();
//        }

//    }
//}
