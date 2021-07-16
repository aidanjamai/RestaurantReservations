﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Domain.Repositories;
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

        public RestaurantController(RestaurantRepository restaurants)
        {
            this.restaurants = restaurants;
        }
        [HttpGet("by-city/{city}")]
        public async Task<IActionResult> GetRestaurantsByCity([FromRoute] string city)
        {
            var dtos = await restaurants.GetRestaurantsByCityAsync(city);
            return Ok(dtos);
        }
    }
}