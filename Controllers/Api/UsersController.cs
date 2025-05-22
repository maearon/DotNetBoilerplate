using DotNetBoilerplate.Data;
using DotNetBoilerplate.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DotNetBoilerplate.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/users
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUsers(int page = 1, int pageSize = 10)
        {
            var users = await _userManager.Users
                .OrderBy(u => u.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Email,
                    u.CreatedAt,
                    u.UpdatedAt,
                    MicropostsCount = _context.Microposts.Count(m => m.UserId == u.Id),
                    FollowingCount = _context.Relationships.Count(r => r.FollowerId == u.Id),
                    FollowersCount = _context.Relationships.Count(r => r.FollowedId == u.Id)
                })
                .ToListAsync();

            var totalUsers = await _userManager.Users.CountAsync();
            var totalPages = (int)Math.Ceiling(totalUsers / (double)pageSize);

            return Ok(new
            {
                Users = users,
                TotalUsers = totalUsers,
                TotalPages = totalPages,
                CurrentPage = page
            });
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var micropostsCount = await _context.Microposts.CountAsync(m => m.UserId == id);
            var followingCount = await _context.Relationships.CountAsync(r => r.FollowerId == id);
            var followersCount = await _context.Relationships.CountAsync(r => r.FollowedId == id);

            return Ok(new
            {
                user.Id,
                user.Name,
                user.Email,
                user.CreatedAt,
                user.UpdatedAt,
                MicropostsCount = micropostsCount,
                FollowingCount = followingCount,
                FollowersCount = followersCount
            });
        }

        // GET: api/users/{id}/microposts
        [HttpGet("{id}/microposts")]
        public async Task<IActionResult> GetUserMicroposts(string id, int page = 1, int pageSize = 10)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var microposts = await _context.Microposts
                .Where(m => m.UserId == id)
                .OrderByDescending(m => m.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new
                {
                    m.Id,
                    m.Content,
                    m.ImagePath,
                    m.CreatedAt,
                    m.UpdatedAt,
                    User = new
                    {
                        user.Id,
                        user.Name,
                        user.Email
                    }
                })
                .ToListAsync();

            var totalMicroposts = await _context.Microposts.CountAsync(m => m.UserId == id);
            var totalPages = (int)Math.Ceiling(totalMicroposts / (double)pageSize);

            return Ok(new
            {
                Microposts = microposts,
                TotalMicroposts = totalMicroposts,
                TotalPages = totalPages,
                CurrentPage = page
            });
        }

        // GET: api/users/{id}/following
        [HttpGet("{id}/following")]
        public async Task<IActionResult> GetUserFollowing(string id, int page = 1, int pageSize = 10)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var followingIds = await _context.Relationships
                .Where(r => r.FollowerId == id)
                .Select(r => r.FollowedId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var following = await _userManager.Users
                .Where(u => followingIds.Contains(u.Id))
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Email,
                    u.CreatedAt,
                    u.UpdatedAt
                })
                .ToListAsync();

            var totalFollowing = await _context.Relationships.CountAsync(r => r.FollowerId == id);
            var totalPages = (int)Math.Ceiling(totalFollowing / (double)pageSize);

            return Ok(new
            {
                Following = following,
                TotalFollowing = totalFollowing,
                TotalPages = totalPages,
                CurrentPage = page
            });
        }

        // GET: api/users/{id}/followers
        [HttpGet("{id}/followers")]
        public async Task<IActionResult> GetUserFollowers(string id, int page = 1, int pageSize = 10)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var followerIds = await _context.Relationships
                .Where(r => r.FollowedId == id)
                .Select(r => r.FollowerId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var followers = await _userManager.Users
                .Where(u => followerIds.Contains(u.Id))
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Email,
                    u.CreatedAt,
                    u.UpdatedAt
                })
                .ToListAsync();

            var totalFollowers = await _context.Relationships.CountAsync(r => r.FollowedId == id);
            var totalPages = (int)Math.Ceiling(totalFollowers / (double)pageSize);

            return Ok(new
            {
                Followers = followers,
                TotalFollowers = totalFollowers,
                TotalPages = totalPages,
                CurrentPage = page
            });
        }
    }
}
