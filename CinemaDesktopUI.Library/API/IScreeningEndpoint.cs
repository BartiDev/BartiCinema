using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public interface IScreeningEndpoint
    {
        Task<List<DescriptiveScreeningModel>> GetByFilmId(int filmId);
        Task<List<DescriptiveScreeningModel>> GetByStartTime(DateTime today);
        Task<ScreeningModel> GetById(int id);
        Task<int> CountReservedSeats(int id);
    }
}