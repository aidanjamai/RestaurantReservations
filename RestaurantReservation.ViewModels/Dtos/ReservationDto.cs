using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.ViewModels.DTOs
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int PartySize { get; set; }
        public bool Confirmed { get; set; }
        public Guid RestaurantId { get; set; }

    }
}
