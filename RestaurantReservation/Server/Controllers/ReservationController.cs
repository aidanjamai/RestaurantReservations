using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Domain.Repositories;
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
        private readonly ReservationRepository reservation;

        public ReservationController(ReservationRepository reservation)
        {
            this.reservation = reservation;
        }
        [HttpGet("by-restaurant/{restaurant}")]
        public async Task<IActionResult> GetReservationsByCity([FromRoute] string restaurant)
        {
            var dtos = await reservation.GetReservationsByRestAsync(restaurant);
            return Ok(dtos);
        }

        [HttpGet("by-month/{month}")]
        public async Task<IActionResult> GetReservationsBymonth([FromRoute] string month)
        {
            var dtos = await reservation.GetReservationsByRestAsync(month);
            return Ok(dtos);
        }

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetReservationsByName([FromRoute] string name)
        {
            var dtos = await reservation.GetReservationsByNameAsync(name);
            return Ok(dtos);
        }

    }
}

