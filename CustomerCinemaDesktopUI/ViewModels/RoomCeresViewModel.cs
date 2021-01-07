using Caliburn.Micro;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class RoomCeresViewModel
    {
        private readonly IEventAggregator _events;

        public int ScreeningId { get; set; }
        public RoomModel CurrentRoom { get; set; }
        public List<SeatModel> SeatsToReserve { get; set; } = new List<SeatModel>();
        public List<ReservedSeat> ReservedSeats { get; set; }


        public RoomCeresViewModel(IEventAggregator events)
        {
            _events = events;
        }


        public void ReserveSeat(int seatId, Button button)
        {
            if(button.Background == Brushes.LightGray)
            {
                SeatModel seat = new SeatModel()
                {
                    Id = seatId,
                    RoomId = CurrentRoom.Id,
                    Row = Convert.ToInt32(Math.Ceiling((seatId - 165) / 5.0))
                };
                seat.Number = seatId - 165 - 5 * (seat.Row - 1);

                SeatsToReserve.Add(seat);

                button.Background = Brushes.MediumSeaGreen;
            }
            else if(button.Background == Brushes.MediumSeaGreen)
            {
                SeatsToReserve.Remove(SeatsToReserve.Find(x => x.Id == seatId));

                button.Background = Brushes.LightGray;
            }
        }

        public void CheckIfFree(int seatId, Button button)
        {
            if(ReservedSeats != null)
            {
                if(ReservedSeats.Find(x => x.SeatId == seatId) != null)
                {
                    button.Background = Brushes.DarkRed;
                }
            }
        }


        public void Back()
        {
            _events.PublishOnUIThreadAsync(new OpenScreeningViewEvent() { ScreeningId = this.ScreeningId });
        }

        public void Continue()
        {
            _events.PublishOnUIThreadAsync(new ContinueToCustomerInfoEvent()
            {
                SeatsToReserve = this.SeatsToReserve,
                ScreeningId = this.ScreeningId
            });
        }
    }
}
