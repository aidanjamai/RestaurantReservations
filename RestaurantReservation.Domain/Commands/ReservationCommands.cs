using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Commands
{
    public static class ReservationCommands
    {
        public const string GetReservationsByRest = @"SELECT * FROM RestarantReservations WHERE RestaurantName = @Restaurant";
        public const string GetReservationsByMonth = @"SELECT * FROM Reservation WHERE DATEPART(month, Date) = @Month";
        public const string GetReservationsByName = @"SELECT * FROM UserReservations WHERE FirstName = @Name";

    }
}
