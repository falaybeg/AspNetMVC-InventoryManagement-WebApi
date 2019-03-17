using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using NtierApp.Repository.Infrastucture;
using NtierApp.Repository.Infrastucture.Contract;
using NTierApp.Business;
using NTierApp.Business.Interface;
using NTierApp.WebApp.Areas.HelpPage.Controllers;
using NTierApp.WebApp.Controllers;
using NTierApp.WebApp.Resolver;
using Unity;
using Unity.Injection;

namespace NTierApp.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>();


            container.RegisterType<ICategoryBusiness, CategoryBusiness>();
            container.RegisterType<ISupplierBusiness, SupplierBusiness>();
            container.RegisterType<IProductBusiness, ProductBusiness>();
            container.RegisterType<IPurchaseBusiness, PurchaseBusiness>();
            container.RegisterType<IOrdersBusiness, OrdersBusiness>();
            container.RegisterType<IUserBusiness, UserBusiness>();



            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

        }
    }
}
