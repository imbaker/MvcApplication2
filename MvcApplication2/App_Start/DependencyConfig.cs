using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.App_Start
{
    using System.Web.Mvc;

    using Autofac.Integration.Mvc;

    using MvcApplication2.Database;
    using MvcApplication2.Database.Entities.Interfaces;

    public class DependencyConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<Db>().As<IContext>().InstancePerHttpRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}