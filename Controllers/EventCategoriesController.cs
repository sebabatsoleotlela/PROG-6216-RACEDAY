using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.DTOs;
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
        public async Task<IActionResult> PostEventCategory([FromBody] CreateEventCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = new EventCategory
            {
                EventId = dto.EventId,
                CategoryName = dto.CategoryName,
                DistanceKm = dto.DistanceKm,
                EntryFee = dto.EntryFee
            };

            _context.EventCategories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Event category created successfully!", categoryId = category.CategoryId });
        }
    }
}
