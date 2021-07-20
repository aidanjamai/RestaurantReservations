using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationReservation.Server.Services;
using RestaurantReservation.Domain.Repositories;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RestaurantReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantRepository restaurants;
        private readonly JwtService jwt;

        public RestaurantController(RestaurantRepository restaurants, JwtService jwt)
        {
            this.restaurants = restaurants;
            this.jwt = jwt;
        }
        [HttpGet("by-city/{city}")]
        public async Task<IActionResult> GetRestaurantsByCity([FromRoute] string city)
        {
            var dtos = await restaurants.GetRestaurantsByCityAsync(city);
            return Ok(dtos);
        }
        [HttpGet("by-state/{state}")]
        public async Task<IActionResult> GetRestaurantsByState([FromRoute] string state)
        {
            var dtos = await restaurants.GetRestaurantsByStateAsync(state);
            return Ok(dtos);
        }
        [HttpGet("by-cuisine/{cuisine}")]
        public async Task<IActionResult> GetRestaurantsByCuisine([FromRoute] string cuisine)
        {
            var dtos = await restaurants.GetRestaurantsByCuisineAsync(cuisine);
            return Ok(dtos);
        }
        [HttpPost("CreateRest")]
        public async Task<IActionResult> CreateRest(RestaurantDto rest)
        {
            //Console.WriteLine(login.Email);
            await restaurants.CreateRestAsync(rest);

            return Ok();
        }
    }
}
