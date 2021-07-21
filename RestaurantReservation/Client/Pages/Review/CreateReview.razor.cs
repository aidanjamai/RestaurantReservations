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

namespace RestaurantReservation.Client.Pages.Review
{
    public partial class CreateReview : ComponentBase
    {
        private RestIdView action = new RestIdView();
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


                var createReview = await Http.PostAsJsonAsync("api/Review/CreateReview", action);
                loading = false;
                StateHasChanged();
                CreateReviewHandler(createReview);

            }
            catch (Exception ex)
            {
                error = ex.Message;
                loading = false;
                StateHasChanged();
            }
        }

        private async void CreateReviewHandler(HttpResponseMessage createReview)
        {
            if (createReview.IsSuccessStatusCode)
            {
                AuthorizationService.Token = await createReview.Content.ReadAsStringAsync();
                
            }
        }

    }
}
