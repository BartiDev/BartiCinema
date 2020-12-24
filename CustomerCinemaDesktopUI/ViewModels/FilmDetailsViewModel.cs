using Caliburn.Micro;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class FilmDetailsViewModel
    {
        private FilmModel _film;
        private readonly IEventAggregator _events;

        public FilmModel Film
        {
            get { return _film; }
            set { _film = value; }
        }

        public FilmDetailsViewModel(FilmModel film, IEventAggregator events)
        {
            _film = film;
            _events = events;
        }

        public void Home()
        {
            _events.PublishOnUIThreadAsync(new BackToHomeEventModel());
        }
    }
}
