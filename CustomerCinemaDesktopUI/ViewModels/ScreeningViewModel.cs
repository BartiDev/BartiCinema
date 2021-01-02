using CinemaDesktopUI.Library.API;
using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class ScreeningViewModel
    {
        private ScreeningModel _screening;
        private FilmModel _film;
        private RoomModel _room;
        private readonly IScreeningEndpoint _screeningEndpoint;
        private readonly IFilmEndpoint _filmEndpoint;
        private readonly IRoomEndpoint _roomEndpoint;

        public ScreeningModel Screening
        {
            get { return _screening; }
            set { _screening = value; }
        }
        public FilmModel Film
        {
            get { return _film; }
            set { _film = value; }
        }
        public RoomModel Room
        {
            get { return _room; }
            set { _room = value; }
        }

        public ScreeningViewModel(IScreeningEndpoint screeningEndpoint, IFilmEndpoint filmEndpoint, IRoomEndpoint roomEndpoint)
        {
            _screeningEndpoint = screeningEndpoint;
            _filmEndpoint = filmEndpoint;
            _roomEndpoint = roomEndpoint;
        }

        public async Task LoadData(int screeningId)
        {
            Screening = await _screeningEndpoint.GetById(screeningId);
            Film = await _filmEndpoint.GetById(Screening.FilmId);
            Room = await _roomEndpoint.GetById(Screening.RoomId);
        }
    }
}
