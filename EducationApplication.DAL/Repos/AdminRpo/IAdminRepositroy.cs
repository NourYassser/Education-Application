//using EducationApplication.DAL.Data.Model;

//namespace EducationApplication.DAL.Repos.AdminRpo
//{
//    public interface IAdminRepositroy
//    {

//        // get user for ban and un ban method  
//        User GetUsertById(string id);

//        //------------------------------------------------------------------------------------

//        // get all student 
//        IEnumerable<Student> GetAllStudentAsync();

//        // get by id or name (student)
//        Student GetStudentById(string id);
//        Student GetStudentByName(string name);


//        // add student 
//        public void AddStudent(Student student);
//        // edit student 
//        public void UpdateStudent(Student student);

//        // delete student 
//        public void DeleteStudent(Student student);

//        //------------------------------------------------------------------------------------

//        // get all instractour 
//        IEnumerable<Instructor> GetAllInstructo();
//        IEnumerable<Instructor> GetAllInstructorPanding();

//        // get by id or name instractour) 
//        Instructor GetInstructorById(string id);
//        Instructor GetInstructorByName(string name);


//        // add instractour  
//        public void AddInstructor(Instructor Instructor);
//        // edit instractour 
//        public void UpdateInstructor(Instructor Instructor);

//        // delete instractour 
//        public void DeleteInstructor(Instructor Instructor);





//        // Approve and deny instractour after login only accses for admin

//        void ApproveInstructorAsync(string instructorId);
//        void DenyInstructorAsync(string instructorId);

//        // ban and un ban users accses for admin
//        void BanUserAsync(string studentId);
//        void UnbanUserAsync(string studentId);


//        // App details some details

//        string NumOfStudent();
//        string NumOfInstructor();
//        string NumOfQuizes();
//        string NumOfAttempes();

//        // role admin only acsses

//        void SaveChanges();

//    }
//}
