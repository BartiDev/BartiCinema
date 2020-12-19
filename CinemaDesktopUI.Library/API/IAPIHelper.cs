using System.Net.Http;

namespace CinemaDesktopUI.Library.API
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
    }
}