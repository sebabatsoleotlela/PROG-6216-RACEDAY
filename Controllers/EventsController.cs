using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;
using RaceDay.API.DTOs;

namespace RaceDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly RaceDayDbContext _context;

        public EventsController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/Events (Public / Participants view all events)
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);
        }

        // GET: api/Events/5 (Get single event details with categories)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var raceEvent = await _context.Events
                .FirstOrDefaultAsync(e => e.EventId == id);

            if (raceEvent == null)
                return NotFound(new { message = "Event not found." });

            return Ok(raceEvent);
        }

        // POST: api/Events (Organiser creates an event)
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var raceEvent = new Event
            {
                EventName = dto.EventName,
                Location = dto.Location,
                EventDate = dto.EventDate,
                Description = dto.Description,
                OrganiserId = dto.OrganiserId
            };

            _context.Events.Add(raceEvent);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Event created successfully!", eventId = raceEvent.EventId });
        }

        // DELETE: api/Events/5 (Organiser deletes an event)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var raceEvent = await _context.Events.FindAsync(id);
            if (raceEvent == null)
                return NotFound(new { message = "Event not found." });

            _context.Events.Remove(raceEvent);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Event deleted successfully." });
        }
    }
}