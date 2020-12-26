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
        public List<ScreeningModel> GetByFilmId(int filmId)
        {
            ScreeningData data = new ScreeningData(_config);
            DateTime dateNow = new DateTime(2020, 3, 12);

            var output = data.GetByFilmID(filmId, dateNow);

            return output;
        }
    }
}
