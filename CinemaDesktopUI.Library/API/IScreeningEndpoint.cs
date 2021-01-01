using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public interface IScreeningEndpoint
    {
        Task<List<ScreeningModel>> GetByFilmId(int filmId);
        Task<List<ScreeningModel>> GetByStartTime(DateTime today);
    }
}