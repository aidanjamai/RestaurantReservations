using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Commands
{
    public static class ReviewCommands
    {
        public const string GetReviewsByRest = @"SELECT * FROM RestUserReview WHERE Name = @Rest";
        public const string RestId = @"SELECT Restaurant.Id FROM Restaurant WHERE Name = @Name";
        public const string CreateReview = @"Insert into Review values  ( @Id, @RestaurantId, @UserId, @Rating, @Comments)";
        

    }
}
