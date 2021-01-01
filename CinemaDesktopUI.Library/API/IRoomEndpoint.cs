using CinemaDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public interface IRoomEndpoint
    {
        Task<RoomModel> GetById(int id);
    }
}