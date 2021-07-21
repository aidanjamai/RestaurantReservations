using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.ViewModels.Views
{
    public class RestUserReviewView : ReviewDto
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
