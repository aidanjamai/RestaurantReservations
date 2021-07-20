using Microsoft.AspNetCore.Components;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace RestaurantReservation.Client.Pages.Review
{
    public partial class ByRest : ComponentBase
    {
        private string rest;
        private List<ReviewDto> reviews = new();

        private async void GetReviews()
        {
            reviews = await Http.GetFromJsonAsync<List<ReviewDto>>($"api/Review/by-rest/{rest}");

            StateHasChanged();
        }
    }
}
