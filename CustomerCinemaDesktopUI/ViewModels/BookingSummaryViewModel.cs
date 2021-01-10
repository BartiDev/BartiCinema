using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class BookingSummaryViewModel
    {
        public RoomModel Room { get; set; }
        public CustomerModel Customer { get; set; }
        public ScreeningModel Screening { get; set; }
        public FilmModel Film { get; set; }
        public List<SeatModel> SeatsToReserve { get; set; }
        public TicketModel Ticket { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Ticket.Price * SeatsToReserve.Count;
            }
        }

        public void Confirm()
        {

        }
    }
}
