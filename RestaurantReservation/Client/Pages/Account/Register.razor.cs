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

namespace RestaurantReservation.Client.Pages.Account
{
    public partial class Register : ComponentBase
    {
        private AccountDto action = new AccountDto();
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
                
                
                var register = await Http.PostAsJsonAsync("api/Account/Register", action);
                loading = false;
                StateHasChanged();
                RegisterHandler(register);




            }
            catch (Exception ex)
            {
                error = ex.Message;
                loading = false;
                StateHasChanged();
            }
        }

        private async void RegisterHandler(HttpResponseMessage register)
        {
            if (register.IsSuccessStatusCode)
            {
                AuthorizationService.Token = await register.Content.ReadAsStringAsync();
                var returnUrl = NavigationManager.QueryString("returnUrl") ?? "/";
                NavigationManager.NavigateTo(returnUrl);
            }
        }


    }
}
