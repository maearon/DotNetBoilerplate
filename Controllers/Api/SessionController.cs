using DotNetBoilerplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotNetBoilerplate.Controllers.Api
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SessionController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET /api/session/me
        [HttpGet("me")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated." });
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.Name // or other custom fields
            });
        }
    }
}
