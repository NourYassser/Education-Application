using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EducationApplication.BLL.Dtos.Accounts;
using EducationApplication.DAL.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EducationApplication.BLL.Manager.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Register(RegisterDto model);
        Task<AuthResponseDTO> Login(LoginDTO model);
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDTO> Register(RegisterDto model)
        {
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                UserType = model.UserType.ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }

            // Add user to role based on UserType
            await _userManager.AddToRoleAsync(user, user.UserType.ToString());

            return new AuthResponseDTO
            {
                Token = await GenerateJwtToken(user),
                Username = user.UserName,
                UserType = user.UserType.ToString()
            };
        }

        public async Task<AuthResponseDTO> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid email or password");
            }

            return new AuthResponseDTO
            {
                Token = await GenerateJwtToken(user),
                Username = user.UserName,
                UserType = user.UserType
            };
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.UserType.ToString())
        };

            // Add roles to claims
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
