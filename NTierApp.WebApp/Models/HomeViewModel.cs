using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierApp.WebApp.Models
{
    public class HomeViewModel
    {
        public decimal TotalProductValues { get; set; }
        public int TotalSuppliers { get; set; }
        public int TotalProducts { get; set; }
        public decimal TotalOrders { get; set; }

        public  IEnumerable<ApplicationUserr> User { get; set; }
        public IEnumerable<Orders>  Orders { get; set; }

    }
}