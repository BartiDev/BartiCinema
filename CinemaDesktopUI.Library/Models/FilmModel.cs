using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaDesktopUI.Library.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int LenghtMin { get; set; }
    }
}
