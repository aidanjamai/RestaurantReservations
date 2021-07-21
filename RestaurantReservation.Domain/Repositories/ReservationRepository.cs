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
    }
}
