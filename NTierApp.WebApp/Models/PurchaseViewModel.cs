using NTier.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NTierApp.WebApp.Models
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public string Description { get; set; }
        public bool Confirmation { get; set; }
        public DateTime ConfirmationTime { get; set; }

        public Product Product { get; set; }
        public ApplicationUserr User { get; set; }

    }
}