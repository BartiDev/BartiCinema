﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaDesktopUI.Library.Models
{
    public class ScreeningModel
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
