using Caliburn.Micro;
using CinemaDesktopUI.Library.API;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class FilmDetailsViewModel : Screen
    {
        private FilmModel _film;
        private readonly IEventAggregator _events;
        private readonly IScreeningEndpoint _screeningEndpoint;

        public FilmModel Film
        {
            get { return _film; }
            set { _film = value; NotifyOfPropertyChange(() => Film); }
        }

        public FilmDetailsViewModel(IEventAggregator events, IScreeningEndpoint screeningEndpoint)
        {
            _events = events;
            _screeningEndpoint = screeningEndpoint;
        }

        public void Home()
        {
            _events.PublishOnUIThreadAsync(new BackToHomeEventModel());
        }

        public async Task Screenings()
        {
            await _events.PublishOnUIThreadAsync(new ShowFilmScreeningsEvent() { FilmId = Film.Id });
            var result = await _screeningEndpoint.GetByFilmId(Film.Id);
        }
    }
}
