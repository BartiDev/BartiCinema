using Caliburn.Micro;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class BookingCustomerInfoViewModel : Screen
    {
        private CustomerModel _customer;
        private readonly IEventAggregator _events;

        public CustomerModel Customer
        {
            get { return _customer; }
            set { _customer = value; NotifyOfPropertyChange(() => Customer); }
        }


        public BookingCustomerInfoViewModel(IEventAggregator events)
        {
            _events = events;
            Customer = new CustomerModel();
        }


        public void Continue()
        {
            _events.PublishOnUIThreadAsync(new ContinueToSummaryEvent() { Customer = this.Customer });
        }
    }
}
