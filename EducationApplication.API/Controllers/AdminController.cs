using EducationApplication.BLL.Dtos.InstructorDtos;
using EducationApplication.BLL.Dtos.StudentDtos;
using EducationApplication.BLL.Manager.InstructorManager;
using EducationApplication.BLL.Manager.StudentManager;
using Microsoft.AspNetCore.Mvc;

namespace EducationApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IinstructorManager _mngINS;
        private readonly IStudentManager _mngSTU;

        public AdminController(IinstructorManager mngINS, IStudentManager mngSTU)
        {
            _mngINS = mngINS;
            _mngSTU = _mngSTU;
        }
        [HttpGet]
        public IActionResult GetInstructors()
        {
            return Ok(_mngINS.GetAllInstructorsAsync());
        }
        public IActionResult GetStudents()
        {
            return Ok(_mngSTU.GetAllStudentsAsync());
        }
        [HttpPost]
        public IActionResult AddInstructors(InstructorAddDto dto)
        {
            _mngINS.AddInstructorAsync(dto);
            return NoContent();
        }
        public IActionResult AddStudents(StudentAddDto dto)
        {
            _mngSTU.AddStudentAsync(dto);
            return NoContent();
        }
    }
}
