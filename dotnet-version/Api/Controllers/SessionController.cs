using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            // Return current user info (mocked)
            return Ok(new { user = User.Identity.Name });
        }

        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // JWT logout is handled client-side (token deletion)
            return Ok(new { message = "Logged out" });
        }
    }
}
