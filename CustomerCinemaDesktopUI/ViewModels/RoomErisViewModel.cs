﻿using Caliburn.Micro;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class RoomErisViewModel : Screen
    {
        private readonly IEventAggregator _events;
        private List<SeatModel> _seatsToReserve = new List<SeatModel>();

        public int ScreeningId { get; set; }
        public RoomModel CurrentRoom { get; set; }
        public List<ReservedSeatModel> ReservedSeats { get; set; }
        public List<SeatModel> SeatsToReserve
        {
            get { return _seatsToReserve; }
            set { _seatsToReserve = value; NotifyOfPropertyChange(() => CanContinue); }
        }



        public RoomErisViewModel(IEventAggregator events)
        {
            _events = events;
        }


        public void ReserveSeat(int seatId, Button button)
        {
            if (button.Background == Brushes.LightGray)
            {
                SeatModel seat = new SeatModel()
                {
                    Id = seatId,
                    RoomId = CurrentRoom.Id,
                    Row = Convert.ToInt32(Math.Ceiling((seatId - 120) / 5.0))
                };
                seat.Number = seatId - 120 - 5 * (seat.Row - 1);

                SeatsToReserve.Add(seat);
                NotifyOfPropertyChange(() => CanContinue);

                button.Background = Brushes.MediumSeaGreen;
            }
            else if (button.Background == Brushes.MediumSeaGreen)
            {
                SeatsToReserve.Remove(SeatsToReserve.Find(x => x.Id == seatId));
                NotifyOfPropertyChange(() => CanContinue);

                button.Background = Brushes.LightGray;
            }
        }

        public void CheckIfFree(int seatId, Button button)
        {
            if (ReservedSeats != null)
            {
                if (ReservedSeats.Find(x => x.SeatId == seatId) != null)
                {
                    button.Background = Brushes.DarkRed;
                }
            }
            if (SeatsToReserve?.Count > 0)
            {
                if (SeatsToReserve.Find(x => x.Id == seatId) != null)
                {
                    button.Background = Brushes.MediumSeaGreen;
                }
            }
        }

        public void Back()
        {
            _events.PublishOnUIThreadAsync(new OpenScreeningViewEvent() { ScreeningId = this.ScreeningId });
        }

        public bool CanContinue
        {
            get
            {
                if (SeatsToReserve.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
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
