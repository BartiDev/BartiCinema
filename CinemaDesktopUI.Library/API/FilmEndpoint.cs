using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public class FilmEndpoint : IFilmEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public FilmEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<FilmModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Film"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<FilmModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<FilmModel>> GetFiveByTitle(string title)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/Film/GetFiveByTitle/{title}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<FilmModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<FilmModel>> GetAllByTitle(string title)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/Film/GetAllByTitle/{title}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<FilmModel>>();
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
