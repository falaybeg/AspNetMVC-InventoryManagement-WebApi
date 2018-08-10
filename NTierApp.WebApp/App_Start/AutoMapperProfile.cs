using AutoMapper;
using NTier.Domain;
using NTierApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierApp.WebApp.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Category, CategoryViewModel>();
            CreateMap<Orders, OrderViewModel>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Purchase, PurchaseViewModel>();


            CreateMap<CategoryViewModel, Category>();
            CreateMap<OrderViewModel, Orders>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<PurchaseViewModel, Purchase>();

        }
    }
}