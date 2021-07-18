using Microsoft.AspNetCore.Components;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace RestaurantReservation.Client.Pages.Reservation
{
    public partial class ByRestaurant : ComponentBase
    {
        private string restaurant;
        private List<ReservationDto> reservations = new();
        
        private async void GetReservations()
        {
            reservations = await Http.GetFromJsonAsync<List<ReservationDto>>($"api/Reservation/by-restaurant/{restaurant}");
            
            StateHasChanged();
        }
    }
}
