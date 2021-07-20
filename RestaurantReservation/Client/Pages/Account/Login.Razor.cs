
using Microsoft.AspNetCore.Components;
using RestaurantReservation.ViewModels.Actions;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RestaurantReservation.Client.Pages.Account
{
    public partial class Login : ComponentBase
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
                /*await AuthenticationService.Login(action);
                var returnUrl = NavigationManager.QueryString("returnUrl") ?? "/";
                NavigationManager.NavigateTo(returnUrl);*/
                Console.WriteLine(action.Email);
                Console.WriteLine(action.Password);
                await Http.PostAsJsonAsync("api/Account/login", action);
                Console.WriteLine(action.Email);
                loading = false;


            }
            catch (Exception ex)
            {
                error = ex.Message;
                loading = false;
                StateHasChanged();
            }
        }

        
    }
}
