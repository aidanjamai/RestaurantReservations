using System;
using Dapper;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Domain.Commands;
using RestaurantReservation.ViewModels.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReservation.ViewModels.Actions;
using System.Security.Cryptography;


namespace RestaurantReservation.Domain.Repositories
{
    public class AccountRepository : BaseRepository
    {
        public AccountRepository(IConfiguration config) : base(config)
        {

        }

        public async Task<AccountDto> LoginAsync(LoginAction action)
        {
            action.Password = GenerateHash(action.Password);
            

            using var conn = Connection;
            return await conn.QueryFirstOrDefaultAsync<AccountDto>(AccountCommands.Login, new { action.Email, action.Password });


        }

        public string GenerateHash(string password)
        {
            var data = Encoding.UTF8.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            return Encoding.UTF8.GetString(data);



        }
    }
}
