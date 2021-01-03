using Caliburn.Micro;
using CinemaDesktopUI.Library.API;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class ScreeningViewModel
    {
        private readonly IScreeningEndpoint _screeningEndpoint;
        private readonly IFilmEndpoint _filmEndpoint;
        private readonly IRoomEndpoint _roomEndpoint;
        private readonly IEventAggregator _events;

        public int FreeSeats { get; set; }
        public ScreeningModel Screening { get; set; }
        public FilmModel Film { get; set; }
        public RoomModel Room { get; set; }


        public ScreeningViewModel(IScreeningEndpoint screeningEndpoint, IFilmEndpoint filmEndpoint, 
            IRoomEndpoint roomEndpoint, IEventAggregator events)
        {
            _screeningEndpoint = screeningEndpoint;
            _filmEndpoint = filmEndpoint;
            _roomEndpoint = roomEndpoint;
            _events = events;
        }

        public async Task LoadData(int screeningId)
        {
            Screening = await _screeningEndpoint.GetById(screeningId);
            Film = await _filmEndpoint.GetById(Screening.FilmId);
            Room = await _roomEndpoint.GetById(Screening.RoomId);

            int takenSeats = await _screeningEndpoint.CountReservedSeats(screeningId);
            FreeSeats = Room.NoSeats - takenSeats;
        }

        public async Task Book()
        {
            await _events.PublishOnUIThreadAsync(new OpenRoomViewEvent()
            {
                Room = this.Room,
                ScreeningId = Screening.Id
            });
        }

        public async Task Home()
        {
            await _events.PublishOnUIThreadAsync(new BackToHomeEvent());
        }
    }
}
