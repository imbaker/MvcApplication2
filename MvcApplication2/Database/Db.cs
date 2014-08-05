namespace MvcApplication2.Database
{
    using System.Data.Entity;

    using MvcApplication2.Database.Entities;

    public class Db : DbContext, Entities.Interfaces.IContext
    {
        public Db()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Application> Applications { get; set; }
        public IDbSet<Link> Links { get; set; } 
    }
}