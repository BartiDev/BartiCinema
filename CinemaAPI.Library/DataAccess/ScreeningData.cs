using CinemaAPI.Library.Internal.DataAccess;
using CinemaAPI.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<DescriptiveScreeningModel> GetByFilmId(int filmId, DateTime dateNow)
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

        public ScreeningModel GetById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<ScreeningModel, dynamic>("dbo.spScreening_GetById", new { id }, "BartiCinemaDB");

            return output.FirstOrDefault();
        }

        public int CountReservedSeats(int ScreeningId)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<int, dynamic>("dbo.spScreening_CountReservedSeats", new { ScreeningId }, "BartiCinemaDB");

            return output.FirstOrDefault();
        }

        public List<ReservedSeat> GetAllReservedSeats(int ScreeningId)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<ReservedSeat, dynamic>("dbo.spScreening_GetAllReservedSeats", new { ScreeningId }, "BartiCinemaDB");

            return output;
        }
    }
}
