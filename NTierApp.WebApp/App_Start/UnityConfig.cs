using Microsoft.Practices.Unity.Configuration;
using NtierApp.Repository.Infrastucture;
using NtierApp.Repository.Infrastucture.Contract;
using NTierApp.Business;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Areas.HelpPage.Controllers;
using NTierApp.WebApp.Controllers;
using NTierApp.WebApp.Controllers.Api;
using NTierApp.WebApp.Resolver;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace NTierApp.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<ICategoryBusiness, CategoryBusiness>();
            container.RegisterType<ISupplierBusiness, SupplierBusiness>();
            container.RegisterType<IProductBusiness, ProductBusiness>();
            container.RegisterType<IPurchaseBusiness, PurchaseBusiness>();
            container.RegisterType<IOrdersBusiness, OrdersBusiness>();
            container.RegisterType<IUserBusiness, UserBusiness>();


            container.RegisterType<UserManagementController>(new InjectionConstructor());
            container.RegisterType<HelpController>(new InjectionConstructor());


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}