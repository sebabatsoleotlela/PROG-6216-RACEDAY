using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RaceDay.API.Data;
using RaceDay.API.Models;
using RaceDay.API.DTOs;

namespace RaceDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RaceDayDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher = new();

        public AuthController(RaceDayDbContext context)
        {
            _context = context;
        }

        // POST: api/Auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1. Check if email already exists (Ensures uniqueness)
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (existingUser != null)
            {
                return BadRequest(new { message = "An account with this email already exists." });
            }

            // 2. Create the user object
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                RoleId = dto.RoleId,
                CreatedAt = DateTime.UtcNow
            };

            // 3. Hash the password securely
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            // 4. Save to database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully!", userId = user.UserId });
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RegisterDto dto)
        {
            // Find user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            // Verify the hashed password
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(new { message = "Login successful!", userId = user.UserId, roleId = user.RoleId, fullName = user.FullName });
        }
    }
}