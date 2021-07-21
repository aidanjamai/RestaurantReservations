using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.ViewModels.DTOs
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }

    }
}
