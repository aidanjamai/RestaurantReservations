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
        public async Task<IActionResult> GetReservationsByRest([FromRoute] string restaurant)
        {
            var dtos = await reservation.GetReservationsByRestAsync(restaurant);
            return Ok(dtos);
        }

        [HttpGet("by-month/{month}")]
        public async Task<IActionResult> GetReservationsBymonth([FromRoute] int month)
        {
            var dtos = await reservation.GetReservationsByMonthAsync(month);
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

