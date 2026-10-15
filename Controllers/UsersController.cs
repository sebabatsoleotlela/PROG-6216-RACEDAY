using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RaceDay.API.Data;
using RaceDay.API.Models;
using RaceDay.API.DTOs;

namespace RaceDay.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RaceDayDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher = new();

        public UsersController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET: api/users/5 (View Profile)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound(new { message = "User not found." });

            // Map RoleId to a readable role name
            string roleName = user.RoleId == 1 ? "Organiser" : "Participant";

            return Ok(new
            {
                user.UserId,
                user.FullName,
                user.Email,
                user.RoleId,
                RoleName = roleName,
                user.CreatedAt
            });
        }

        // PUT: api/users/change-password
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
                return NotFound(new { message = "User not found." });

            // Verify old password
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.CurrentPassword);
            if (result == PasswordVerificationResult.Failed)
                return BadRequest(new { message = "Incorrect current password." });

            // Hash new password and save
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.NewPassword);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Password changed successfully!" });
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found." });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User account deleted successfully." });
        }

        // POST: api/users/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if email already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (existingUser != null)
                return BadRequest(new { message = "Email is already registered." });

            var user = new User
            {
                FullName = dto.Username,
                Email = dto.Email,
                RoleId = 2// 1 for Organiser, 2 for Participant (or adjust per your DB)
            };

            // Hash the password securely
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully!", userId = user.UserId });
        }

        // POST: api/users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return Unauthorized(new { message = "Invalid email or password." });

            // Verify password hash
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Invalid email or password." });

            string roleName = user.RoleId == 1 ? "Organiser" : "Participant";

            return Ok(new
            {
                message = "Login successful!",
                userId = user.UserId,
                fullName = user.FullName,
                email = user.Email,
                role = roleName
            });
        }
    }
}