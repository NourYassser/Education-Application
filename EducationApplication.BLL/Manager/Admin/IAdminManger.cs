/*using EducationApplication.BLL.Dtos.Admin.InstructorDtos;
namespace EducationApplication.BLL.Manager.Admin
{
    public interface IAdminManger
    {

         get all  student 
        IEnumerable<StudentReadDto> GetAllStudentAsync();

         get by id or name student 
        StudentReadDto GetStudentById(string id);
        StudentReadDto GetStudentByName(string name);


         add student 
        public void AddStudent(StudentAddDto StudentAddDto);
         edit student 
        public void UpdateStudent(StudentUpdateDto StudentUpdateDto);

         delete student 
        public void DeleteStudent(string id);

        --------------------------------------------------------------------------------

         get all instractour 
        IEnumerable<InstructorReadDto> GetAllInstructors();
        IEnumerable<InstructorStatusDto> GetAllInstructorPanding();

         get by id or name instractour
        InstructorReadDto GetInstructorById(string id);

        InstructorReadDto GetInstructorByName(string name);


         add instractour  
        public void AddInstructor(InstructorAddDto InstructorAddDto);
         edit instractour 
        InstrurctorUpdateDto GetInstructorByIdForUpdate(string id);
        public void UpdateInstructor(InstrurctorUpdateDto IstrurctorUpdateDto);

         delete instractour 
        public void DeleteInstructor(string id);


        --------------------------------------------------------------------------


         Approve and deny instractour after login only accses for admin

        string ApproveInstructorAsync(string id);
        string DenyInstructorAsync(string id);

         ban and un ban users accses for admin
        void BanUserAsync(string studentId);
        void UnbanUserAsync(string studentId);


         App details instractour 

        string NumOfStudent();
        string NumOfInstructor();
        string NumOfQuizes();
        string NumOfAttempes();


         role admin only acsses

        void SaveChanges();
    }
}
*/