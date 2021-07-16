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
    }
}
