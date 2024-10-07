using Microsoft.AspNetCore.Mvc;
using TravelSV.API.Models;
using TravelSV.API.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TravelSV.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes(Application.Json)]
    [Produces(Application.Json)]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }


        [HttpGet]
        public async Task<ActionResult> GetRoles()
        {
            var roles = await _rolesService.GetRolesAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole([FromBody] Role role)
        {
            var result = await _rolesService.CreateRoleAsync(role);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRole([FromBody] Role role)
        {
            var result = await _rolesService.UpdateRoleAsync(role);
            return Ok(result);
        }
    }
}
