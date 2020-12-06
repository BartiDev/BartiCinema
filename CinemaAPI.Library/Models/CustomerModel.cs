using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAPI.Library.Models
{
    public class CustomerModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
