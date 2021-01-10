using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.EventModels
{
    public class ContinueToSummaryEvent
    {
        public CustomerModel Customer { get; set; }
        public TicketModel Ticket { get; set; }
    }
}
