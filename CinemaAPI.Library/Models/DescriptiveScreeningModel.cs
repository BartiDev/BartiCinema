﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAPI.Library.Models
{
    public class DescriptiveScreeningModel
    {
        public int Id { get; set; }
        public string FilmTitle { get; set; }
        public string RoomName { get; set; }
        public DateTime StartTime { get; set; }
    }
}
