﻿using System;
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

            var output = data.GetFilms();

            return output;
        }
    }
}