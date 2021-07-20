using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Commands
{
    public static class RestaurantCommands
    {
        public const string GetRestaurantsByCity = @"SELECT * FROM Restaurant WHERE City = @City";
        public const string GetRestaurantsByState = @"SELECT * FROM Restaurant WHERE State = @State";
        public const string GetRestaurantsByCuisine = @"SELECT * FROM Restaurant WHERE Cuisine = @Cuisine";
        public const string CreateRest = @"Insert into Restaurant values  ( @Id, @Name, @State, @Zip, @City, @Street, @HouseNumber, @Cuisine, @IsOpen, @AdminId)";
    }
}
