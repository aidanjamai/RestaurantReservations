using Microsoft.AspNetCore.Components;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RestaurantReservation.ViewModels.Views;

namespace RestaurantReservation.Client.Pages.Reservation
{
    public partial class ByRestaurant : ComponentBase
    {
        private string restaurant;
        private List<RestReservationsView> reservations = new();
        
        private async void GetReservations()
        {
            reservations = await Http.GetFromJsonAsync<List<RestReservationsView>>($"api/Reservation/by-restaurant/{restaurant}");
            
            StateHasChanged();
        }
    }
}
