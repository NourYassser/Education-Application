//using EducationApplication.DAL.Data.DbHelper;
//using EducationApplication.DAL.Data.Model;

//namespace EducationApplication.DAL.Repos.AdminRpo
//{
//    public class AdminRepositroy : IAdminRepositroy
//    {
//        private readonly EducationDbContext _Context;

//        public AdminRepositroy(EducationDbContext Context)
//        {
//            _Context = Context;
//        }
//        public void AddInstructor(Instructor Instructor)
//        {
//            _Context.Add(Instructor);
//            _Context.SaveChanges();
//        }

//        public void AddStudent(Student student)
//        {
//            _Context.Add(student);
//            SaveChanges();
//        }



//        public void DeleteInstructor(Instructor Instructor)
//        {

//            Instructor.IsDeleted = true;
//            SaveChanges();
//        }

//        public void DeleteStudent(Student student)
//        {
//            student.IsDeleted = true;
//            SaveChanges();
//        }

//        public IEnumerable<Instructor> GetAllInstructo()
//        {
//            return _Context.Instructors.Where(x => x.Status == ApprovalStatus.Approved & x.IsDeleted == false).ToList();
//        }

//        public IEnumerable<Student> GetAllStudentAsync()
//        {
//            return _Context.Students.Where(x => x.IsDeleted == false).ToList();
//        }

//        public Instructor GetInstructorById(string id)
//        {
//            return _Context.Instructors.FirstOrDefault(Key => Key.Id == id.ToString());
//        }

//        public Instructor GetInstructorByName(string name)
//        {
//            return _Context.Instructors.FirstOrDefault(Key => Key.UserName == name);

//        }

//        public Student GetStudentById(string id)
//        {
//            return _Context.Students.FirstOrDefault(Key => Key.Id == id);

//        }

//        public Student GetStudentByName(string name)
//        {
//            return _Context.Students.FirstOrDefault(Key => Key.UserName == name.ToString());

//        }




//        public void UpdateInstructor(Instructor Instructor)
//        {
//            if (Instructor.Status == ApprovalStatus.Denied)
//            {
//                Instructor.IsDeleted = true;
//            }
//            SaveChanges();
//        }

//        public void UpdateStudent(Student student)
//        {
//            SaveChanges();
//        }




//        public void SaveChanges()
//        {
//            _Context.SaveChanges();
//        }

//        public void ApproveInstructorAsync(string InstructorId)
//        {
//            var instructor = _Context.Instructors.FirstOrDefault(key => key.Id == InstructorId);
//            if (instructor != null)
//            {
//                instructor.Status = ApprovalStatus.Approved;
//                _Context.Update(instructor);
//                _Context.SaveChanges();
//            }
//        }


//        public void DenyInstructorAsync(string InstructorId)
//        {
//            var instructor = _Context.Instructors.FirstOrDefault(key => key.Id == InstructorId);
//            if (instructor != null)
//            {
//                instructor.Status = ApprovalStatus.Denied;
//                instructor.IsDeleted = true;
//                _Context.Update(instructor);
//                _Context.SaveChanges();
//            }
//        }



//        public void BanUserAsync(string UserId)
//        {
//            var users = _Context.Users.FirstOrDefault(key => key.Id == UserId);
//            users.LockoutEnabled = true;
//            _Context.Update(users);
//            _Context.SaveChanges();

//        }

//        public void UnbanUserAsync(string UserId)
//        {
//            var users = _Context.Users.FirstOrDefault(key => key.Id == UserId);
//            users.LockoutEnabled = false;
//            _Context.Update(users);
//            _Context.SaveChanges();
//        }

//        public User GetUserById(string id)
//        {
//            return _Context.User.FirstOrDefault(key => key.Id == id);
//        }

//        public string NumOfStudent()
//        {
//            return _Context.Students.Count().ToString();
//        }

//        public string NumOfInstructor()
//        {
//            return _Context.Instructors.Count().ToString();
//        }

//        public string NumOfQuizes()
//        {
//            return _Context.Quizzes.Count().ToString();
//        }

//        public string NumOfAttempes()
//        {
//            return _Context.Attempts.Count().ToString();
//        }

//        public IEnumerable<Instructor> GetAllInstructorPanding()
//        {
//            return _Context.Instructors
//                .Where(x => x.Status == ApprovalStatus.Pending)
//                .ToList();
//        }
//    }
//}
