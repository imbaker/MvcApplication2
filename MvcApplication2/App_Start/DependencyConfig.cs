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
    using MvcApplication2.Database.Repositories;
    using MvcApplication2.Database.Repositories.Interfaces;

    public class DependencyConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<Db>().AsSelf();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}