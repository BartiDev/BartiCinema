using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace CinemaDesktopUI.Library.API
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient;
        private readonly IConfiguration _config;

        public HttpClient ApiClient
        {
            get { return _apiClient; }
        }

        public APIHelper(IConfiguration config)
        {
            Initialize();
            _config = config;
        }

        public void Initialize()
        {
            // TODO: Get this line to work correctly
            //string api = _config.GetSection("api").Value;

            string api = "https://localhost:5001/";

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
