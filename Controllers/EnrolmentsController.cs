using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;
using RaceDay.API.DTOs;

namespace RaceDay.API.Controllers
{
    [Route("api/enrolments")]
    [ApiController]
    public class EnrolmentsController : ControllerBase
    {
        private readonly RaceDayDbContext _context;

        public EnrolmentsController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/enrolments
        [HttpGet]
        public async Task<IActionResult> GetEnrolments()
        {
            var enrolments = await _context.Enrolments
                .Include(e => e.Participant)
                .Include(e => e.EventCategory)
                .ToListAsync();
            return Ok(enrolments);
        }

        // GET: api/enrolments/user/5 (View races a specific user joined)
        // GET: api/enrolments/user/5 (View races a specific user joined)
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserEnrolments(int userId)
        {
            var enrolments = await _context.Enrolments
                .Where(e => e.ParticipantId == userId)
                .Include(e => e.EventCategory)
                .ToListAsync();

            return Ok(enrolments);
        }

        // POST: api/enrolments
        [HttpPost]
        public async Task<IActionResult> CreateEnrolment([FromBody] EnrolDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1. Verify user exists
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
                return NotFound(new { message = "User not found." });

            // 2. Verify category exists
            var category = await _context.EventCategories.FindAsync(dto.CategoryId);
            if (category == null)
                return NotFound(new { message = "Event category not found." });

            // 3. Create the enrolment matching your model properties
            var enrolment = new Enrolment
            {
                ParticipantId = dto.UserId,
                CategoryId = dto.CategoryId,
                EnrolmentDate = DateTime.Now,
                PaymentStatus = "Pending"
            };

            _context.Enrolments.Add(enrolment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnrolments), new { id = enrolment.EnrolmentId }, enrolment);
        }
    }
}