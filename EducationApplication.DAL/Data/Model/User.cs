using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EducationApplication.DAL.Data.Model
{
    public enum TypeUser
    {
        Instructor,
        Student
    }
    public enum GenderType
    {
        Male = 1,
        Female

    }

    public enum ApprovalStatus
    {
        Pending,
        Approved,
        Denied
    }
    public class User : IdentityUser
    {
        [Range(5, 120)]
        public string UserType { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    public class Student : User
    {
        public bool IsBanned { get; set; } = false;
        public ICollection<Enrollment> Enrollments = new HashSet<Enrollment>();

        //Student With Attempts
        /*public virtual ICollection<Attempts> Attempts { get; set; } = new HashSet<Attempts>();*/
    }
    public class Instructor : User
    {
        public ApprovalStatus? Status { get; set; } = ApprovalStatus.Pending;

        //  Instructor with Quizzes
        /* public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
         public virtual ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
         public virtual ICollection<Quizzes> quizzes { get; set; } = new HashSet<Quizzes>();*/
    }
    public class Admin : User { }
}

