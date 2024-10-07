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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersServices;

        public UsersController(IUsersService usersServices)
        {
            this._usersServices = usersServices;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] User user)
        {
            try
            {
                var result = await _usersServices.CreateUser(user);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUsersAsync()
        {
            try
            {
                var result = await _usersServices.GetUsers();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> GetUserByIdAsync([FromBody] Login login)
        {
            try
            {
                var user = await _usersServices.GetUserByCriteria(x => x.Name == login.Email && x.Password == login.Password);

                if (user == null)
                {
                    throw new ArgumentException("Usuario Invalido");
                }

                if (user.Active)
                {
                    throw new ArgumentException("Este usuario ya tiene una sesión activa");
                }
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync([FromBody] User user)
        {
            try
            {
                var result = await _usersServices.UpdateUser(user);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync([FromQuery] Guid id)
        {
            try
            {
                var result = await _usersServices.DeleteUser(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
