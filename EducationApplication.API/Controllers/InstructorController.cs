/*using EducationApplication.BLL.Dtos.Instructor;
using EducationApplication.BLL.Manager.InstructorManager;
using Microsoft.AspNetCore.Mvc;

namespace EducationApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IinstructorManager _mng;

        public InstructorController(IinstructorManager mng)
        {
            _mng = mng;
        }
        [HttpGet]
        public IActionResult GetInstructorById(string id)
        {
            return Ok(_mng.GetInsById(id));
        }

        [HttpGet]
        public IActionResult GetAllStudentsAttempts(int quizId)
        {
            return Ok(_mng.GetStudentOfQuizAttempet(quizId));
        }
        [HttpGet]
        public IActionResult QuizScores(int quizId)
        {
            return Ok(_mng.ShowScoresOfQuiz(quizId));
        }
        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateInstructor(int Id, UpdateInstructorProfileDto dto)
        {
            if (Id == null || Id != dto.Id)
            {
                return BadRequest();
            }
            _mng.UpdateInstructorProfile(dto);
            return NoContent();
        }
    }
}
*/