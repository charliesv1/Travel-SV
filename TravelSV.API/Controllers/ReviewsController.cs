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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _reviewsService.GetReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            var review = await _reviewsService.GetReviewByIdAsync(id);
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            var createdReview = await _reviewsService.CreateReviewAsync(review);
            return Ok(createdReview);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview([FromBody] Review review)
        {
            var updatedReview = await _reviewsService.UpdateReviewAsync(review);
            return Ok(updatedReview);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviewsService.DeleteReviewAsync(id);
            return Ok();
        }
    }
}
