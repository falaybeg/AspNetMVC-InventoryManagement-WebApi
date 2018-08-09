using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
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

            container.RegisterType<ICategoryBusiness, CategoryBusiness>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();


            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<HelpController>(new InjectionConstructor());
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
        }
    }
}
