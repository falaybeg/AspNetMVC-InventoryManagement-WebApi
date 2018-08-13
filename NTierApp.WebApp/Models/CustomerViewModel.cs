using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierApp.WebApp.Models
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public DateTime RegisteredDate { get; set; }

    }
}