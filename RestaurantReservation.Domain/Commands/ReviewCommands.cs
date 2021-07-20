using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Commands
{
    public static class ReviewCommands
    {
        public const string GetReviewsByRest = @"SELECT * FROM Review JOIN Restaurant ON Review.RestaurantId = Restaurant.Id WHERE Name = @Rest";

    }
}
