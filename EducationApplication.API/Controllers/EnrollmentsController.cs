using EducationApplication.BLL.Dtos.EnrollmentsDtos;
using EducationApplication.BLL.Manager.EnrollmentsManager;
using Microsoft.AspNetCore.Mvc;

namespace EducationApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentsManager _mng;

        public EnrollmentsController(IEnrollmentsManager mng)
        {
            _mng = mng;
        }
        [HttpGet("GetAll")]
        public IActionResult GetEnrollments()
        {
            return Ok(_mng.GetAllEnrollmentsAsync());
        }
        [HttpPost("Adding New Enrollments")]
        public IActionResult AddEnrollments(EnrollmentsAddDto dto)
        {
            _mng.AddEnrollmentsAsync(dto);
            return NoContent();
        }
        [HttpDelete("Soft-Deleting an Enrollments")]
        public IActionResult SoftDeleteEnrollments(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _mng.DeleteEnrollmentsAsync(id);
            return NoContent();
        }
        [HttpDelete("Hard-Deleting an Enrollments")]
        public IActionResult HardDeleteEnrollments(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _mng.HardDeleteEnrollmentsAsync(id);
            return NoContent();
        }
    }
}
