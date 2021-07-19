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

        public async Task<AccountDto> LoginAsync(AccountDto account)
        {
            account.Password = GenerateHash(account.Password);
            

            using var conn = Connection;
            return await conn.QueryFirstOrDefaultAsync<AccountDto>(AccountCommands.Login, new { account.Email, account.Password });


        }

        public async Task RegisterAsync(AccountDto account)
        {
            account.Password = GenerateHash(account.Password);
            account.Id = Guid.NewGuid();

            using var conn = Connection;
            await conn.ExecuteAsync(AccountCommands.Register, account);


        }

        public string GenerateHash(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);



        }
    }
}
