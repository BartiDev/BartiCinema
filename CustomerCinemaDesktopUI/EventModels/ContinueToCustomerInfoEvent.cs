using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.EventModels
{
    public class ContinueToCustomerInfoEvent
    {
        public int ScreeningId { get; set; }
        public List<SeatModel> SeatsToReserve { get; set; }
    }
}
