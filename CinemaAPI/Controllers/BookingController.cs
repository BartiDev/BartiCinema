using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Library.DataAccess;
using CinemaAPI.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IConfiguration _config;

        public BookingController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("FinalizeBooking")]
        public bool FinalizeBooking([FromBody] ArrayList paramList)
        {
            int screeningId = JsonConvert.DeserializeObject<int>(paramList[0].ToString());
            int ticketId = JsonConvert.DeserializeObject<int>(paramList[1].ToString());
            string firstName = paramList[2].ToString();
            string lastName = paramList[3].ToString();
            string emailAddress = paramList[4].ToString();
            List<int> seatsToReserve = JsonConvert.DeserializeObject<List<int>>(paramList[5].ToString());

            BookingData data = new BookingData(_config);

            bool result = data.FinalizeBooking(screeningId, ticketId, firstName,
                lastName, emailAddress, seatsToReserve);

            return result;
        }
    }
}
