namespace MvcApplication2
{
    using System.Data.Entity;
    using System.Data.Entity.Core;
    using System.Runtime.InteropServices;

    using MvcApplication2.Entities;

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