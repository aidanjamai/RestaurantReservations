using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Domain.Repositories;
using RestaurantReservation.ViewModels.DTOs;
using RestaurantReservation.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RestaurantReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewRepository reviews;

        public ReviewController(ReviewRepository reviews)
        {
            this.reviews = reviews;
        }
        [HttpGet("by-rest/{rest}")]
        public async Task<IActionResult> GetReviewsByRest([FromRoute] string rest)
        {
            var dtos = await reviews.GetReviewsByRestAsync(rest);

            return Ok(dtos);
        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview(RestIdView review)
        {
            

            review.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await reviews.CreateReviewAsync(review);

            return Ok();
        }
    }
}
