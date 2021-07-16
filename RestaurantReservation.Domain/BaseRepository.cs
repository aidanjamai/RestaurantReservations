using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain
{
    public abstract class BaseRepository
    {
        private readonly string _conectionString;

        public BaseRepository(IConfiguration config)
        {
            _conectionString = config.GetConnectionString("Default");
        }

        public IDbConnection Connection => new SqlConnection(_conectionString);
        
    }
}
