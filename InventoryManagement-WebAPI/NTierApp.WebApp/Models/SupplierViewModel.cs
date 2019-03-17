using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierApp.WebApp.Models
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}