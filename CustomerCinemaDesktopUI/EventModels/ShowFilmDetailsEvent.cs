using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.EventModels
{
    public class ShowFilmDetailsEvent
    {
        public FilmModel film { get; set; }

        public ShowFilmDetailsEvent(FilmModel filmModel)
        {
            film = filmModel;
        }
    }
}
