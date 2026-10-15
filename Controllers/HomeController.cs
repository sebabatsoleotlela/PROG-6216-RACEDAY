using Microsoft.AspNetCore.Mvc;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetGuide()
        {
            return Ok(new
            {
                project = "RaceDay API",
                status = "Running successfully",
                instructions = "Welcome! Use Swagger UI for interactive testing.",
                swaggerUrl = "/swagger",
                quickGuide = new
                {
                    register = "POST /api/users/register - Pass { fullName, email, password, roleId } (1 for Organiser, 2 for Participant)",
                    login = "POST /api/users/login - Pass { email, password }",
                    viewEvents = "GET /api/events",
                    viewCategories = "GET /api/eventcategories",
                    viewResults = "GET /api/results"
                }
            });
        }
    }
}
