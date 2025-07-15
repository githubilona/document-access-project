using DocumentAccessApprovalSystem.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocumentAccessApprovalSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static readonly List<(string Username, string Password, string Role)> Users = new()
        {
            ("user", "password", "User"),
            ("approver", "password", "Approver")
        };

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = Users.FirstOrDefault(u => u.Username == dto.Username && u.Password == dto.Password);
            if (user == default)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("very-long-secret-key-at-least-32-bytes!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
} 
