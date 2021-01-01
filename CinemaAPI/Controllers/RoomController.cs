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
    public class RoomController : ControllerBase
    {
        private readonly IConfiguration _config;

        public RoomController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public RoomModel GetById(int id)
        {
            RoomData data = new RoomData(_config);

            var output = data.GetById(id);

            return output;
        }
    }
}
