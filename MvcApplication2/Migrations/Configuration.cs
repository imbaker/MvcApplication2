namespace MvcApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using MvcApplication2.Database;
    using MvcApplication2.Database.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Applications.AddOrUpdate( new Application() { Category = "Desktop Application", Name = "Picasa", Created = new DateTime(2014,8,1), Modified = new DateTime(2014, 8, 2)});

            context.Categories.AddOrUpdate(new Category(){Name="Category 1", Created=new DateTime(2014,9,1), Modified = new DateTime(2014,9,2)});
        }
    }
}
