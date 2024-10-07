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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productRepository;

        public ProductsController(IProductsService productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] Product product)
        {
            var createdProduct = await _productRepository.CreateProductAsync(product);
            return Ok(createdProduct);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] Product product)
        {
            var updatedProduct = await _productRepository.UpdateProductAsync(product);
            return Ok(updatedProduct);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return Ok();
        }
    }
}
