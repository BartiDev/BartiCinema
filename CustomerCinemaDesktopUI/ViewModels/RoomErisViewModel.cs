using Caliburn.Micro;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class RoomErisViewModel
    {
        private readonly IEventAggregator _events;

        public int ScreeningId { get; set; }
        public RoomModel CurrentRoom { get; set; }
        public List<SeatModel> SeatsToReserve { get; set; } = new List<SeatModel>();

        public void ReserveSeat(int seatId)
        {
            SeatModel seat = new SeatModel()
            {
                Id = seatId,
                RoomId = CurrentRoom.Id,
                Row = Convert.ToInt32(Math.Ceiling((seatId - 120) / 5.0))
            };
            seat.Number = seatId - 120 - 5 * (seat.Row - 1);

            SeatsToReserve.Add(seat);
        }

        public RoomErisViewModel(IEventAggregator events)
        {
            _events = events;
        }

        public void Back()
        {
            _events.PublishOnUIThreadAsync(new OpenScreeningViewEvent() { ScreeningId = this.ScreeningId });
        }

        public void Continue()
        {
            _events.PublishOnUIThreadAsync(new ContinueBookingEvent() { SeatToReserve = this.SeatsToReserve });
        }
    }
}
