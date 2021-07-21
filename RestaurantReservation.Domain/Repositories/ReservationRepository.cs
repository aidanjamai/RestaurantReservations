using System;
using Dapper;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Domain.Commands;
using RestaurantReservation.ViewModels.DTOs;
using RestaurantReservation.ViewModels.Views;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Repositories
{
    public class ReservationRepository : BaseRepository
    {
        public ReservationRepository(IConfiguration config) : base(config)
        {

        }

        public async Task<IEnumerable<RestReservationsView>> GetReservationsByRestAsync(string restaurant)
        {
            using var conn = Connection;
            return await conn.QueryAsync<RestReservationsView>(ReservationCommands.GetReservationsByRest, new { restaurant });


        }
        public async Task<IEnumerable<ReservationDto>> GetReservationsByMonthAsync(int month)
        {
            using var conn = Connection;
            return await conn.QueryAsync<ReservationDto>(ReservationCommands.GetReservationsByMonth, new { month });


        }
        public async Task<IEnumerable<UserReservationsView>> GetReservationsByNameAsync(string name)
        {
            using var conn = Connection;
            return await conn.QueryAsync<UserReservationsView>(ReservationCommands.GetReservationsByName, new { name });


        }

        public async Task CreateReservationAsync(RestIdResView data)
        {
            ReservationDto reservation = new();
            reservation.Id = Guid.NewGuid();
            reservation.Date = data.Date;
            reservation.Location = data.Location;
            reservation.PartySize = data.PartySize;
            reservation.Confirmed = data.Confirmed;
            reservation.UserId = data.UserId;

            using var conn = Connection;
            var RestaurantId = await conn.QueryFirstOrDefaultAsync<RestIdView>(ReviewCommands.RestId, new { data.Name });

            reservation.RestaurantId = RestaurantId.Id;
            await conn.ExecuteAsync(ReservationCommands.CreateReservation, reservation);


        }
    }
}
