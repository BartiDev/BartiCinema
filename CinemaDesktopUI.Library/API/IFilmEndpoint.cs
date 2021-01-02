using CinemaDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public interface IFilmEndpoint
    {
        Task<List<FilmModel>> GetAll();
        Task<List<FilmModel>> GetFiveByTitle(string title);
        Task<List<FilmModel>> GetAllByTitle(string title);
        Task<FilmModel> GetById(int id);
    }
}