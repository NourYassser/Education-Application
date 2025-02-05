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
            _mngSTU = mngSTU;
        }
        [HttpGet("GetInstructors")]
        public IActionResult GetInstructors()
        {
            return Ok(_mngINS.GetAllInstructorsAsync());
        }
        [HttpGet("GetStudents")]
        public IActionResult GetStudents()
        {
            return Ok(_mngSTU.GetAllStudentsAsync());
        }
        [HttpPost("AddInstructors")]
        public IActionResult AddInstructors(InstructorAddDto dto)
        {
            _mngINS.AddInstructorAsync(dto);
            return NoContent();
        }
        [HttpPost("AddStudents")]
        public IActionResult AddStudents(StudentAddDto dto)
        {
            _mngSTU.AddStudentAsync(dto);
            return NoContent();
        }
    }
}
