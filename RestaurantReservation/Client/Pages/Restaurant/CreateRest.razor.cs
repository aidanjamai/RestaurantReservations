using Microsoft.AspNetCore.Components;
using RestaurantReservation.Client.Helpers;
using RestaurantReservation.Client.Services;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RestaurantReservation.Client.Pages.Restaurant
{
    public partial class CreateRest : ComponentBase
    {
        private RestaurantDto action = new RestaurantDto();
        private bool loading;
        private string error;

        protected override void OnInitialized()
        {
            // redirect to home if already logged in
            /*if (AuthenticationService.User != null)
            {
                NavigationManager.NavigateTo("");
            }*/
        }

        private async void HandleValidSubmit()
        {
            loading = true;
            try
            {


                var createRest = await Http.PostAsJsonAsync("api/Restaurant/CreateRest", action);
                loading = false;
                StateHasChanged();
                CreateRestHandler(createRest);

            }
            catch (Exception ex)
            {
                error = ex.Message;
                loading = false;
                StateHasChanged();
            }
        }

        private async void CreateRestHandler(HttpResponseMessage createRest)
        {
            if (createRest.IsSuccessStatusCode)
            {
                AuthorizationService.Token = await createRest.Content.ReadAsStringAsync();
                var returnUrl = NavigationManager.QueryString("returnUrl") ?? "/";
                NavigationManager.NavigateTo(returnUrl);
            }
        }

    }
}
