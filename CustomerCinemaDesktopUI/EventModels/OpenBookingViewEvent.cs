using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.EventModels
{
    public class OpenBookingViewEvent
    {
        public RoomModel Room { get; set; }
        public ScreeningModel Screening { get; set; }
        public FilmModel Film { get; set; }
    }
}
