namespace MvcApplication2.Database
{
    using System.Data.Entity;

    using MvcApplication2.Database.Entities;

    public class Db : DbContext
    {
        public Db()
            : base("DefaultConnection")
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Link> Links { get; set; } 
    }
}