using Microsoft.AspNetCore.Mvc;
using TravelSV.API.Contexts;
using static System.Net.Mime.MediaTypeNames;

namespace TravelSV.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes(Application.Json)]
    [Produces(Application.Json)]
    public class DatabaseController : ControllerBase
    {
        private readonly TravelSvDbContext _context;

        public DatabaseController(TravelSvDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("reset-database")]
        public async Task<ActionResult> Post()
        {
            if (await _context.Database.CanConnectAsync())
            {
                await _context.Database.EnsureDeletedAsync();
            }

            await _context.Database.EnsureCreatedAsync();
            return Ok();
        }
    }
}
