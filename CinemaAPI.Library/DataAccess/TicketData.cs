using CinemaAPI.Library.Internal.DataAccess;
using CinemaAPI.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAPI.Library.DataAccess
{
    public class TicketData
    {
        private readonly IConfiguration _config;

        public TicketData(IConfiguration config)
        {
            _config = config;
        }

        public List<TicketModel> GetAll()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<TicketModel, dynamic>("dbo.spTicket_GetAll", new { }, "BartiCinemaDB");

            return output;
        }
    }
}
