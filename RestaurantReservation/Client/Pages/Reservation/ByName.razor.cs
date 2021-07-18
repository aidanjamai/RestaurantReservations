﻿using Microsoft.AspNetCore.Components;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace RestaurantReservation.Client.Pages.Reservation
{
    public partial class ByName : ComponentBase
    {
        private string name;
        private List<ReservationDto> reservations = new();

        private async void GetReservations()
        {
            reservations = await Http.GetFromJsonAsync<List<ReservationDto>>($"api/Reservation/by-name/{name}");

            StateHasChanged();
        }
    }
}
