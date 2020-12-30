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
    public class FilmController : ControllerBase
    {
        private readonly IConfiguration _config;

        public FilmController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public List<FilmModel> Get()
        {
            FilmData data = new FilmData(_config);

            var output = data.GetAll();

            return output;
        }

        [HttpGet]
        [Route("GetFiveByTitle/{title}")]
        public List<FilmModel> GetFiveByTitle(string title)
        {
            FilmData data = new FilmData(_config);

            var output = data.GetFiveByTitle(title);

            return output;
        }

        [HttpGet]
        [Route("GetAllByTitle/{title}")]
        public List<FilmModel> GetAllByTitle(string title)
        {
            FilmData data = new FilmData(_config);

            var output = data.GetAllByTitle(title);

            return output;
        }
    }
}
