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
    public class TicketController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TicketController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<TicketModel> GetAll()
        {
            TicketData data = new TicketData(_config);

            var output = data.GetAll();

            return output;
        }
    }
}
