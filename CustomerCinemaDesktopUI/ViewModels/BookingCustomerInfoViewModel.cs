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
    public class BookingCustomerInfoViewModel : Screen
    {
        private CustomerModel _customer;
        private readonly IEventAggregator _events;
        private readonly ITicketEndpoint _ticketEndpoint;
        private TicketModel _selectedTicket;
        private List<TicketModel> _tickets;


        public CustomerModel Customer
        {
            get { return _customer; }
            set { _customer = value; NotifyOfPropertyChange(() => Customer); }
        }
        public TicketModel SelectedTicket
        {
            get { return _selectedTicket; }
            set { _selectedTicket = value; NotifyOfPropertyChange(() => SelectedTicket); }
        }
        public List<TicketModel> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; NotifyOfPropertyChange(() => Tickets); }
        }


        public BookingCustomerInfoViewModel(IEventAggregator events, ITicketEndpoint ticketEndpoint)
        {
            _events = events;
            _ticketEndpoint = ticketEndpoint;
            Customer = new CustomerModel();

            LoadTickets();
        }

        public async Task LoadTickets()
        {
            Tickets = await _ticketEndpoint.GetAll();
        }

        public void Continue()
        {
            if(!string.IsNullOrWhiteSpace(Customer.FirstName) &&
                !string.IsNullOrWhiteSpace(Customer.LastName) &&
                !string.IsNullOrWhiteSpace(Customer.EmailAddress) &&
                SelectedTicket != null)
            {
                _events.PublishOnUIThreadAsync(new ContinueToSummaryEvent() 
                { 
                    Customer = this.Customer,
                    Ticket = SelectedTicket
                });
            }
        }

        public void Back()
        {
            _events.PublishOnUIThreadAsync(new BackToBookingEvent() { Customer = this.Customer });
        }
    }
}
