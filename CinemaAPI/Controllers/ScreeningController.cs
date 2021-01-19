using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Library.DataAccess;
using CinemaAPI.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ScreeningController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("GetByFilmId/{filmId}")]
        public List<DescriptiveScreeningModel> GetByFilmId(int filmId)
        {
            ScreeningData data = new ScreeningData(_config);
            DateTime dateNow = new DateTime(2020, 3, 12);

            var output = data.GetByFilmId(filmId, dateNow);

            return output;
        }

        [HttpGet]
        [Route("GetByStartTime")]
        public List<DescriptiveScreeningModel> GetByStartTime(string today, string tomorrow)
        {
            ScreeningData data = new ScreeningData(_config);

            var output = data.GetByStartTime(today, tomorrow);

            return output;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ScreeningModel GetById(int id)
        {
            ScreeningData data = new ScreeningData(_config);

            var output = data.GetById(id);

            return output;
        }

        [HttpGet]
        [Route("CountReservedSeats/{screeningId}")]
        public int CountReservedSeats(int screeningId)
        {
            ScreeningData data = new ScreeningData(_config);

            var output = data.CountReservedSeats(screeningId);

            return output;
        }

        [HttpGet]
        [Route("GetAllReservedSeats/{screeningId}")]
        public List<ReservedSeatModel> GetAllReservedSeats(int screeningId)
        {
            ScreeningData data = new ScreeningData(_config);

            var output = data.GetAllReservedSeats(screeningId);

            return output;
        }
    }
}
