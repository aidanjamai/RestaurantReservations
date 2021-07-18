﻿using Dapper;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Domain.Commands;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantReservation.Domain.Repositories
{
    public class RestaurantRepository : BaseRepository
    {
        public RestaurantRepository(IConfiguration config): base (config)
        {
            
        }

        public async Task<IEnumerable<RestaurantDto>> GetRestaurantsByCityAsync(string city)
        {
            using var conn = Connection;
            return await conn.QueryAsync<RestaurantDto>(RestaurantCommands.GetRestaurantsByCity, new { city });

           
        }

        public async Task<IEnumerable<RestaurantDto>> GetRestaurantsByStateAsync(string state)
        {
            using var conn = Connection;
            return await conn.QueryAsync<RestaurantDto>(RestaurantCommands.GetRestaurantsByState, new { state });


        }

        public async Task<IEnumerable<RestaurantDto>> GetRestaurantsByCuisineAsync(string cuisine)
        {
            using var conn = Connection;
            return await conn.QueryAsync<RestaurantDto>(RestaurantCommands.GetRestaurantsByCuisine, new { cuisine });


        }
    }
}
