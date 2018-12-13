using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierApp.WebApp.Models
{
    public class TopSeller
    {
        public int ProductCount { get; set; }
        public string ProductName { get; set; }
    }

    public class MostSoldCategories
    { 
        public int CategoryCount { get; set; }
        public int TotalCount { get; set; }
        public string CategoryName { get; set; }
    }

    public class MostProfitableProducts
    {
        public decimal Profit { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasingPrice { get; set; }
        public string ProductName { get; set; }
    }

    public class HomeViewModel
    {
        public decimal TotalProductValues { get; set; }
        public int TotalSuppliers { get; set; }
        public int TotalProducts { get; set; }
        public decimal TotalOrders { get; set; }

        public decimal TotalPurchase { get; set; }
        public decimal TotalOrder { get; set; }
        public decimal Profit { get; set; }

        public IEnumerable<ApplicationUserr> User { get; set; }
        public IEnumerable<Purchase> LatesPurchases { get; set; }
        public IEnumerable<Orders> LatesOrders { get; set; }
        //public IEnumerable<Orders> BestSeller { get; set; }
        public IEnumerable<TopSeller> TopSeller { get; set; }
        public IEnumerable<MostSoldCategories> MostSoldCategories { get; set; }
        public IEnumerable<MostProfitableProducts> MostProfitableProducts { get; set; }



    }
}