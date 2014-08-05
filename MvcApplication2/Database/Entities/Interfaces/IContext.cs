// -----------------------------------------------------------------------
// <copyright file="IContext.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MvcApplication2.Database.Entities.Interfaces
{
    using System.Data.Entity;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IContext
    {
        IDbSet<Application> Applications { get; set; }

        int SaveChanges();
    }
}
