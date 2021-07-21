using Microsoft.AspNetCore.Components;
using RestaurantReservation.Client.Helpers;
using RestaurantReservation.Client.Services;
using RestaurantReservation.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RestaurantReservation.Client.Pages.Reservation
{
    public partial class CreateReservation : ComponentBase
    {
        private RestIdResView action = new RestIdResView();
        private bool loading;
        private string error;

        protected override void OnInitialized()
        {

        }

        private async void HandleValidSubmit()
        {
            loading = true;
            try
            {


                var createReservation = await Http.PostAsJsonAsync("api/Reservation/CreateReservation", action);
                loading = false;
                StateHasChanged();
                CreateReservationHandler(createReservation);

            }
            catch (Exception ex)
            {
                error = ex.Message;
                loading = false;
                StateHasChanged();
            }
        }

        private void CreateReservationHandler(HttpResponseMessage createReservation)
        {
            if (createReservation.IsSuccessStatusCode)
            {
                
                var returnUrl = NavigationManager.QueryString("returnUrl") ?? "/";
                NavigationManager.NavigateTo(returnUrl);

            }
        }
    
    }
}
