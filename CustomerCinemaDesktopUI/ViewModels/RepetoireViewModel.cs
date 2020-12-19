using Caliburn.Micro;
using CinemaDesktopUI.Library.API;
using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class RepetoireViewModel : Screen
    {
        private List<FilmModel> _films;
        private readonly IFilmEndpoint _filmEndpoint;

        public List<FilmModel> Films
        {
            get { return _films; }
            set { _films = value; NotifyOfPropertyChange(() => Films); }
        }

        public RepetoireViewModel(IFilmEndpoint filmEndpoint)
        {
            _filmEndpoint = filmEndpoint;

            LoadFilms();
        }

        public async Task LoadFilms()
        {
            Films = await _filmEndpoint.GetAll();
        }
    }
}
