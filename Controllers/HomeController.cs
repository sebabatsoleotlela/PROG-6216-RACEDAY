using Microsoft.AspNetCore.Mvc;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHome()
        {
            string htmlContent = @"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>RaceDay API</title>
                <style>
                    body { font-family: Arial, sans-serif; background-color: #f4f6f9; margin: 0; padding: 40px; color: #333; }
                    .container { max-width: 700px; background: white; padding: 30px; border-radius: 8px; box-shadow: 0 4px 12px rgba(0,0,0,0.1); }
                    h1 { color: #2c3e50; margin-top: 0; }
                    p { line-height: 1.6; }
                    .btn { display: inline-block; background: #3498db; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px; font-weight: bold; margin-top: 15px; }
                    .btn:hover { background: #2980b9; }
                    ul { background: #f8f9fa; padding: 20px 20px 20px 40px; border-radius: 5px; }
                    li { margin-bottom: 8px; }
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>🏁 Welcome to the RaceDay API</h1>
                    <p>Your backend server is up and running successfully! This API manages running, walking, and cycling events, user authentications, and event registrations.</p>
                    
                    <a href='/swagger' class='btn'>Open Swagger UI (Interactive Docs)</a>

                    <h3>Quick Guide:</h3>
                    <ul>
                        <li><strong>Register User:</strong> POST /api/users/register</li>
                        <li><strong>Login User:</strong> POST /api/users/login</li>
                        <li><strong>View Events:</strong> GET /api/events</li>
                        <li><strong>View Categories:</strong> GET /api/eventcategories</li>
                    </ul>
                </div>
            </body>
            </html>";

            return Content(htmlContent, "text/html");
        }
    }
}