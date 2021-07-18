using Microsoft.AspNetCore.Components;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
namespace RestaurantReservation.Client.Pages.Restaurant
{
    public partial class SearchByState : ComponentBase
    {
        private string state;
        private List<RestaurantDto> restaurants = new();
        private async void GetRestaurants()
        {
            restaurants = await Http.GetFromJsonAsync<List<RestaurantDto>>($"api/Restaurant/by-state/{state}");
            StateHasChanged();
        }
    }
}
