using CinemaAPI.Library.Internal.DataAccess;
using CinemaAPI.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaAPI.Library.DataAccess
{
    public class RoomData
    {
        private readonly IConfiguration _config;

        public RoomData(IConfiguration config)
        {
            _config = config;
        }

        public RoomModel GetById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<RoomModel, dynamic>("dbo.spRoom_GetById", new { id }, "BartiCinemaDB");

            return output.FirstOrDefault();
        }
    }
}
