using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [Route("api/eventcategories")]
    [ApiController]
    public class EventCategoriesController : ControllerBase
    {
        private readonly RaceDayDbContext _context;

        public EventCategoriesController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/eventcategories
        [HttpGet]
        public async Task<IActionResult> GetEventCategories()
        {
            var categories = await _context.EventCategories.ToListAsync();
            return Ok(categories);
        }

        // POST: api/eventcategories
        [HttpPost]
        public async Task<IActionResult> CreateEventCategory([FromBody] EventCategory category)
        {
            _context.EventCategories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEventCategories), new { id = category.CategoryId }, category);
        }
    }
}
