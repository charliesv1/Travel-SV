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
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesService _productCategoriesService;

        public ProductCategoriesController(IProductCategoriesService productCategoriesService)
        {
            _productCategoriesService = productCategoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            var productCategories = await _productCategoriesService.GetProductCategories();
            return Ok(productCategories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductCategory([FromBody] ProductCategory productCategory)
        {
            var createdProductCategory = await _productCategoriesService.CreateProductCategory(productCategory);
            return Ok(createdProductCategory);
        }
    }
}
