﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcApplication2
{
    using System.Data.Entity;

    using MvcApplication2.App_Start;
    using MvcApplication2.Database;
    using MvcApplication2.Migrations;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            DependencyConfig.Register();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutomapperConfig.Register();

            System.Data.Entity.Database.SetInitializer<Db>(new MigrateDatabaseToLatestVersion<Db, Configuration>());
        }
    }
}