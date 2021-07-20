using Dapper;
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
    public class ReviewRepository : BaseRepository
    {
        public ReviewRepository(IConfiguration config) : base(config)
        {

        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByRestAsync(string rest)
        {
            using var conn = Connection;
            return await conn.QueryAsync<ReviewDto>(ReviewCommands.GetReviewsByRest, new { rest });


        }

        
    }
}
