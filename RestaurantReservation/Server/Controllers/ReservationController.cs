using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Domain.Repositories;
using RestaurantReservation.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationReservation.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationRepository reservations;

        public ReservationController(ReservationRepository reservations)
        {
            this.reservations = reservations;
        }
        
        [HttpGet("by-restaurant/{restaurant}")]
        public async Task<IActionResult> GetReservationsByRest([FromRoute] string restaurant)
        {
            var dtos = await reservations.GetReservationsByRestAsync(restaurant);
            return Ok(dtos);
        }

        [HttpGet("by-month/{month}")]
        public async Task<IActionResult> GetReservationsBymonth([FromRoute] int month)
        {
            var dtos = await reservations.GetReservationsByMonthAsync(month);
            return Ok(dtos);
        }

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetReservationsByName([FromRoute] string name)
        {
            var dtos = await reservations.GetReservationsByNameAsync(name);
            return Ok(dtos);
        }

        [HttpPost("CreateReservation")]
        public async Task<IActionResult> CreateReview(RestIdResView reservation)
        {


            reservation.UserId = Guid.Parse(User.FindFirst("UserId").Value);
            await reservations.CreateReservationAsync(reservation);

            return Ok();
        }

    }
}

