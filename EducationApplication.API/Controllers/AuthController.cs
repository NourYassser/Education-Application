using EducationApplication.BLL.Dtos.Accounts;
using EducationApplication.BLL.Manager.Auth;
using EducationApplication.DAL.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace EducationApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDTO>> Register(RegisterDto model)
        {
            var result = await _authService.Register(model);
            if (model.UserType == TypeUser.Student.ToString() || model.UserType == TypeUser.Instructor.ToString())
            {
                return Ok(result);
            }
            return BadRequest("User Must Be Either A Student Or An Instructor");
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>> Login(LoginDTO model)
        {
            try
            {
                var result = await _authService.Login(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
