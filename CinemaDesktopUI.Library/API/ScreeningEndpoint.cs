using CinemaDesktopUI.Library.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public class ScreeningEndpoint : IScreeningEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public ScreeningEndpoint(IAPIHelper apiHelper)
        {
            this._apiHelper = apiHelper;
        }

        public async Task<List<ScreeningModel>> GetByFilmId(int filmId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/Screening/GetByFilmId/{filmId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ScreeningModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<ScreeningModel>> GetByStartTime(DateTime today)
        {
            DateTime tomorrow = today.AddDays(1);

            using (HttpResponseMessage response = await _apiHelper.ApiClient.
                GetAsync($"/api/Screening/GetByStartTime?today={today.ToShortDateString()}&tomorrow={tomorrow.ToShortDateString()}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ScreeningModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
