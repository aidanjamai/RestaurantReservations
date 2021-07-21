using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Client.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddTransient(sp =>
            {
                var client = new HttpClient
                {

                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),

                };
                if (!string.IsNullOrEmpty(AuthorizationService.Token))
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AuthorizationService.Token);
                
                
                return client;
            });

            await builder.Build().RunAsync();
        }
    }
}
