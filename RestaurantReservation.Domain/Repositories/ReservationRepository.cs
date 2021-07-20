using System;
using Dapper;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Domain.Commands;
using RestaurantReservation.ViewModels.DTOs;
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

        public async Task<IEnumerable<ReservationDto>> GetReservationsByRestAsync(string restaurant)
        {
            using var conn = Connection;
            return await conn.QueryAsync<ReservationDto>(ReservationCommands.GetReservationsByRest, new { restaurant });


        }
        public async Task<IEnumerable<ReservationDto>> GetReservationsByMonthAsync(int month)
        {
            using var conn = Connection;
            return await conn.QueryAsync<ReservationDto>(ReservationCommands.GetReservationsByMonth, new { month });


        }
        public async Task<IEnumerable<ReservationDto>> GetReservationsByNameAsync(string name)
        {
            using var conn = Connection;
            return await conn.QueryAsync<ReservationDto>(ReservationCommands.GetReservationsByName, new { name });


        }
    }
}
