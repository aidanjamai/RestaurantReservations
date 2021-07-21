using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationReservation.Server.Services;
using RestaurantReservation.Domain.Repositories;
using RestaurantReservation.ViewModels.Actions;
using RestaurantReservation.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Server.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository account;
        private readonly JwtService jwt;

        public AccountController(AccountRepository account, JwtService jwt)
        {

            this.account = account;
            this.jwt = jwt;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login( AccountDto login)
        {
            
            AccountDto dto = await account.LoginAsync(login);
            if(dto == null)
                return Unauthorized();
            var token = jwt.GenerateSecurityToken(dto.Id);

            
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountDto register)
        {
            //Console.WriteLine(login.Email);
            await account.RegisterAsync(register);

            return Ok();
        }


    }
}
