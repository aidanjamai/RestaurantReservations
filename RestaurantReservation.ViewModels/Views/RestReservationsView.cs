using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.ViewModels.Views
{
    public class RestReservationsView : ReservationDto
    {

        public string RestaurantName { get; set; }
        public string State { get; set; }  
        public string City { get; set; }
        public string Cuisine { get; set; }
    }
}
