using CinemaAPI.Library.Internal.DataAccess;
using CinemaAPI.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAPI.Library.DataAccess
{
    public class FilmData
    {
        private readonly IConfiguration _config;

        public FilmData(IConfiguration config)
        {
            _config = config;
        }


        public List<FilmModel> GetAll()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<FilmModel, dynamic>("dbo.spFilm_GetAll", new { }, "BartiCinemaDB");

            return output;
        }

        public List<FilmModel> GetFiveByTitle(string phrase)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<FilmModel, dynamic>("dbo.spFilm_GetFiveByTitle", new { phrase }, "BartiCinemaDB");

            return output;
        }
    }
}
