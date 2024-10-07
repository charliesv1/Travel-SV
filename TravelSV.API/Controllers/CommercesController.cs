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
    public class CommercesController : ControllerBase
    {
        private readonly ICommercesService _commercesService;

        public CommercesController(ICommercesService commercesService)
        {
            _commercesService = commercesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCommerces()
        {
            var commerces = await _commercesService.GetCommerces();
            return Ok(commerces);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetCommerceById(int id)
        {
            var commerce = await _commercesService.GetCommerceById(id);
            return Ok(commerce);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCommerce([FromBody] Commerce commerce)
        {
            var newCommerce = await _commercesService.CreateCommerce(commerce);
            return Ok(newCommerce);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCommerce([FromBody] Commerce commerce)
        {
            var updatedCommerce = await _commercesService.UpdateCommerce(commerce);
            return Ok(updatedCommerce);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCommerce(int id)
        {
            await _commercesService.DeleteCommerce(id);
            return Ok();
        }
    }
}
