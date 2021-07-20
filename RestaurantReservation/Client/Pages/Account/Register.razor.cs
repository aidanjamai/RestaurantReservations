using Microsoft.AspNetCore.Components;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
                
                Console.WriteLine(action.Email);
                Console.WriteLine(action.Password);
                await Http.PostAsJsonAsync("api/Account/Register", action);
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
