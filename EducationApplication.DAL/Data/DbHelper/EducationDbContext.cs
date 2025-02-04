using EducationApplication.DAL.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationApplication.DAL.Data.DbHelper
{
    public class EducationDbContext(DbContextOptions<EducationDbContext> options) : IdentityDbContext<IdentityUser>(options)
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "Instructor", NormalizedName = "INSTRUCTOR" },
            new IdentityRole { Id = "3", Name = "Student", NormalizedName = "STUDENT" });

            modelBuilder.Entity<AnswerResult>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Questions>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Enrollment>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Course>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<QuizResult>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Lecture>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Video>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<PdfFile>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<ExamResult>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Quizzes>()
                        .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Exam>()
                        .HasQueryFilter(a => !a.IsDeleted);



            /*modelBuilder.Entity<Enrollment>()
                        .HasIndex(e => new { e.StudentId, e.CourseId })
                        .IsUnique();*/

            modelBuilder.Entity<Enrollment>()
                        .HasOne(e => e.Course)
                        .WithMany(e => e.Enrollments)
                        .HasForeignKey(e => e.CourseId)
                        .OnDelete(DeleteBehavior.NoAction); // Change to NO ACTION

            modelBuilder.Entity<Enrollment>()
                        .HasOne(e => e.Student)
                        .WithMany(e => e.Enrollments)
                        .HasForeignKey(e => e.StudentId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<QuizResult>()
                        .HasIndex(e => new { e.StudentId, e.QuizId })
                        .IsUnique();

            modelBuilder.Entity<ExamResult>()
                        .HasIndex(e => new { e.StudentId, e.ExamId })
                        .IsUnique();
            /*var x = new Configuration();
            x.Configure(builder);*/
        }
        //Users
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Quizzes> Quizzes { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<QuizResult> QuizResults { get; set; }
        public virtual DbSet<ExamResult> ExamsResult { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<AnswerResult> AnswerResults { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Attempts> Attempts { get; set; }
        public virtual DbSet<PdfFile> PdfFiles { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

    }
}
