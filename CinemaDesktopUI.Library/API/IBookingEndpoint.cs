using CinemaDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public interface IBookingEndpoint
    {
        Task<bool> FinalizeBooking(int screeningId, int ticketId, string firstName, string lastName, string emailAddress, List<int> seatsToreserve);
    }
}