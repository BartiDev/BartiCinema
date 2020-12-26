using CinemaAPI.Library.Internal.DataAccess;
using CinemaAPI.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAPI.Library.DataAccess
{
    public class ScreeningData
    {
        private readonly IConfiguration _config;

        public ScreeningData(IConfiguration config)
        {
            _config = config;
        }

        public List<ScreeningModel> GetByFilmID(int filmId, DateTime dateNow)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<ScreeningModel, dynamic>("dbo.spScreening_GetByFilmId", new { filmId, dateNow }, "BartiCinemaDB");

            return output;
        }
    }
}
