using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.EventModels
{
    public class ContinueBookingEvent
    {
        public int ScreeningId { get; set; }
        public List<SeatModel> SeatToReserve { get; set; }
        public RoomModel Room { get; set; }
    }
}
