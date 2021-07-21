using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace RestaurantReservation.Client.Services
{
    public static class AuthorizationService
    {
        private static string token;
        public static string Token
        {
            get => token;
            set
            {
                token = value;
                Console.WriteLine(token);
                isAuthorized.OnNext(!string.IsNullOrEmpty(token));
                
            }
        }
        private static BehaviorSubject<bool> isAuthorized = new(false);
        public static IObservable<bool> IsAuthorized => isAuthorized;

    }
}
