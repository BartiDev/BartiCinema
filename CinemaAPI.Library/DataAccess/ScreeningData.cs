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

        public List<DescriptiveScreeningModel> GetByFilmID(int filmId, DateTime dateNow)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<DescriptiveScreeningModel, dynamic>("dbo.spDScreening_GetByFilmId", new { filmId, dateNow }, "BartiCinemaDB");

            return output;
        }

        public List<DescriptiveScreeningModel> GetByStartTime(string todayParameter, string tomorrowParameter)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            DateTime today = Convert.ToDateTime(todayParameter);
            DateTime tomorrow = Convert.ToDateTime(tomorrowParameter);

            var output = sql.LoadData<DescriptiveScreeningModel, dynamic>("dbo.spDScreening_GetByStartTime", new { today, tomorrow }, "BartiCinemaDB");

            return output;
        }
    }
}
