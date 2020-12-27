using Caliburn.Micro;
using CinemaDesktopUI.Library.API;
using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class CalendarViewModel : Screen
    {
        private List<ScreeningModel> _screenings;
        private readonly IScreeningEndpoint _screeningEndpoint;

        public List<ScreeningModel> Screenings
        {
            get { return _screenings; }
            set { _screenings = value; NotifyOfPropertyChange(() => Screenings); }
        }

        public CalendarViewModel(IScreeningEndpoint screeningEndpoint)
        {
            _screeningEndpoint = screeningEndpoint;
        }

        public async Task LoadScreeningsByFilmId(int filmId)
        {
            Screenings = await _screeningEndpoint.GetByFilmId(filmId);
        }
    }
}
