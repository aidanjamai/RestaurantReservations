
using Microsoft.AspNetCore.Components;
using RestaurantReservation.Client.Helpers;
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
       // private readonly bool authorized;
        private AccountDto action = new AccountDto();
        private bool loading;
        private string error;

        /*public Login(bool authorized)
        {
            this.authorized = authorized;
        }*/
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

                var login = await Http.PostAsJsonAsync("api/Account/login", action);
                loading = false;
                StateHasChanged();
                LoginHandler(login);



            }
            catch (Exception ex)
            {
                error = ex.Message;
                loading = false;
                StateHasChanged();
            }
        }
        private void LoginHandler(HttpResponseMessage login)
        {
            if (login.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
                //authorized = true;
                /*var returnUrl = NavigationManager.QueryString("returnUrl") ?? "/";*/
                /*NavigationManager.NavigateTo(returnUrl);*/
            }
        }
    }
}
