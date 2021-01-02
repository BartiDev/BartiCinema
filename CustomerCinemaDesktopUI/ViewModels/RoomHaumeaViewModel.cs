using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class RoomHaumeaViewModel
    {
        public RoomModel CurrentRoom { get; set; }
        public List<SeatModel> SeatsToReserve { get; set; }

        public void ReserveSeat(int seatId)
        {
            SeatModel seat = new SeatModel()
            {
                Id = seatId,
                RoomId = CurrentRoom.Id,
                Row = Convert.ToInt32(Math.Ceiling(seatId / 12.0))
            };
            seat.Number = seatId - 12 * (seat.Row - 1);

            SeatsToReserve.Add(seat);
        }
    }
}
