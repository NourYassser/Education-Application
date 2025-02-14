using EducationApplication.BLL.Dtos.CoursesDtos;
using EducationApplication.BLL.Manager.CourseManager;
using Microsoft.AspNetCore.Mvc;

namespace EducationApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles= "Instructor")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _mng;

        public CourseController(ICourseManager mng)
        {
            _mng = mng;
        }
        [HttpGet("GetAll")]
        public IActionResult GetCourses()
        {
            return Ok(_mng.GetAllCoursesAsync());
        }
        [HttpGet("{Id}")]
        public IActionResult GetCourseByID(int id)
        {
            return Ok(_mng.GetCourseByIdAsync(id));
        }
        [HttpPost("Adding New Courses")]
        public IActionResult AddCourse(CourseAddDto dto)
        {
            _mng.AddCourseAsync(dto);
            return NoContent();
        }
        [HttpPut("id")]
        public IActionResult UpdateCourse(int id, CourseUpdateDto dto)
        {
            if (id == null || id != dto.Id)
            {
                return BadRequest();
            }
            _mng.UpdateCourseAsync(dto);
            return NoContent();
        }
        [HttpDelete("Soft-Deleting a Course")]
        public IActionResult SoftDeleteCourse(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _mng.DeleteCourseAsync(id);
            return NoContent();
        }
        [HttpDelete("Hard-Deleting a Course")]
        public IActionResult HardDeleteCourse(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _mng.HardDeleteCourseAsync(id);
            return NoContent();
        }
    }
}
