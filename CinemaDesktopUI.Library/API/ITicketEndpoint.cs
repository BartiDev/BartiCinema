using CinemaDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public interface ITicketEndpoint
    {
        Task<List<TicketModel>> GetAll();
    }
}