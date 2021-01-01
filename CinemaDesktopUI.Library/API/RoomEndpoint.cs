using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public class RoomEndpoint : IRoomEndpoint
    {
        private readonly IAPIHelper _api;

        public RoomEndpoint(IAPIHelper api)
        {
            _api = api;
        }

        public async Task<RoomModel> GetById(int id)
        {
            using (HttpResponseMessage response = await _api.ApiClient.GetAsync($"/api/Room/GetById/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<RoomModel>();
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
