using Microsoft.AspNetCore.Components;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace RestaurantReservation.Client.Pages.Restaurant
{
    public partial class SearchByCity : ComponentBase
    {
        private string city;
        private List<RestaurantDto> restaurants = new();
        private async void GetRestaurants()
        {
            restaurants = await Http.GetFromJsonAsync<List<RestaurantDto>>($"api/Restaurant/by-city/{city}");
            StateHasChanged();
        }
    }
}

