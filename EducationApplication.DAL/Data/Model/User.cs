using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EducationApplication.DAL.Data.Model
{
    public enum TypeUser
    {
        Admin = 1,
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
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public string Address { get; set; }
        public TypeUser UserType { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
    public class Student : User
    {
        public string? Grade { get; set; }
        public bool IsBanned { get; set; } = false;
        public ICollection<Enrollment> Enrollments = new HashSet<Enrollment>();

        //Student With Attempts
        /*        public virtual ICollection<Attempts> Attempts { get; set; } = new HashSet<Attempts>();
        */
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

