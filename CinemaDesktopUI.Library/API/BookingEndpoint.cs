using CinemaDesktopUI.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDesktopUI.Library.API
{
    public class BookingEndpoint : IBookingEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public BookingEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<bool> FinalizeBooking(int screeningId, int ticketId, string firstName, string lastName,
            string emailAddress, List<int> seatsToreserve)
        {

            ArrayList paramList = new ArrayList();

            paramList.Add(screeningId);
            paramList.Add(ticketId);
            paramList.Add(firstName);
            paramList.Add(lastName);
            paramList.Add(emailAddress);
            paramList.Add(seatsToreserve);

            string contents = JsonConvert.SerializeObject(paramList);

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsync("/api/Booking/FinalizeBooking",
                new StringContent(contents, Encoding.UTF8, "application/json")))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
