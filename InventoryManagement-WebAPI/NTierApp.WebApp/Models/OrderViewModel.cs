using Microsoft.AspNet.Identity.EntityFramework;
using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierApp.WebApp.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ConfirmDate { get; set; }
        public bool ConfirmStatus { get; set; }
        public string ShippingAddress { get; set; }

        public  Product Product { get; set; }
        public  ApplicationUserr User { get; set; }
        public IdentityRole UserRole { get; set; }
    }
}