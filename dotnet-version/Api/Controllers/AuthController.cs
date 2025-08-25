using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dotnet_version.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            // TODO: Validate user credentials (mocked for now)
            if (request.Email == "admin@example.com" && request.Password == "password")
            {
                var token = GenerateJwtToken(request.Email);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKeyHere!123"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
