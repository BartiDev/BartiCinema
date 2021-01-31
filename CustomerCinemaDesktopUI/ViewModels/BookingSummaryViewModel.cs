using Caliburn.Micro;
using CinemaDesktopUI.Library.API;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class BookingSummaryViewModel
    {
        private readonly IBookingEndpoint _bookingEndpoint;
        private readonly IEventAggregator _events;

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

        public BookingSummaryViewModel(IBookingEndpoint bookingEndpoint, IEventAggregator events)
        {
            _bookingEndpoint = bookingEndpoint;
            _events = events;
        }

        public void Confirm()
        {
            List<int> seatsId = new List<int>();
            foreach(var seatId in SeatsToReserve)
            {
                seatsId.Add(seatId.Id);
            }

            _bookingEndpoint.FinalizeBooking(Screening.Id, Ticket.Id, Customer.FirstName,
                Customer.LastName, Customer.EmailAddress, seatsId);
        }

        public void Back()
        {
            _events.PublishOnUIThreadAsync(new BackToCustomerInfoEvent());
        }
    }
}
