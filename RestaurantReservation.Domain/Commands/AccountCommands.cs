using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.Commands
{
     public static class AccountCommands
    {
        public const string Login = @"
            SELECT 
                Email, 
                PhoneNumber, 
                LastName, 
                Id, 
                FirstName, 
                MiddleInitial, 
                State, 
                Zip, 
                City, 
                Street, 
                HouseNumber 
            FROM Account 
            WHERE Email = @Email AND Password = @Password";

        public const string Register = @"Insert into Account values  ( @Id, @Password, @FirstName, @MiddleInitial, @LastName, @Email, @PhoneNumber, @State, @Zip, @City, @Street, @HouseNumber)";
    }

}
