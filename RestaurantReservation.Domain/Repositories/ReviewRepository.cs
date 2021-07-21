using Dapper;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Domain.Commands;
using RestaurantReservation.ViewModels.DTOs;
using RestaurantReservation.ViewModels.Views;
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

        public async Task<IEnumerable<RestUserReviewView>> GetReviewsByRestAsync(string rest)
        {
            using var conn = Connection;

            return await conn.QueryAsync<RestUserReviewView>(ReviewCommands.GetReviewsByRest, new { rest });


        }

        public async Task CreateReviewAsync(RestIdView data)
        {
            ReviewDto review = new();
            review.Id = Guid.NewGuid();
            review.Rating = data.Rating;
            review.Comments = data.Comments;
            review.UserId = data.UserId;

            using var conn = Connection;
            var RestaurantId = await conn.QueryFirstOrDefaultAsync<RestIdView>(ReviewCommands.RestId, new { data.Name });

            review.RestaurantId = RestaurantId.Id;
            await conn.ExecuteAsync(ReviewCommands.CreateReview, review);


        }


    }
}
