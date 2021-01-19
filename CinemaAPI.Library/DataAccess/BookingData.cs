using CinemaAPI.Library.Internal.DataAccess;
using CinemaAPI.Library.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CinemaAPI.Library.DataAccess
{
    public class BookingData
    {
        private readonly IConfiguration _config;

        public BookingData(IConfiguration config)
        {
            _config = config;
        }

        public bool FinalizeBooking(int screeningId, int ticketId, string firstName, string lastName, 
            string emailAddress, List<int> seatsToReserve)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var dt = new DataTable();
            dt.Columns.Add("SeatId", typeof(int));
            foreach(var seatId in seatsToReserve)
            {
                dt.Rows.Add(seatId);
            }

            var spParams = new
            {
                screeningId,
                ticketId,
                firstName,
                lastName,
                emailAddress,
                seatsToReserve = dt.AsTableValuedParameter("SeatIdUDTT")
            };

            var result = sql.SaveData<dynamic>("dbo.spBooking_FinalizeBooking", spParams, "BartiCinemaDB");

            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
