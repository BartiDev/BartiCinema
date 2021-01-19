using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAPI.Library.Models
{
    public class ReservedSeatModel
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int SeatId { get; set; }
    }
}
