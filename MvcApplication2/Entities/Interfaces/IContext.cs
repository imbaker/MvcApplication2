// -----------------------------------------------------------------------
// <copyright file="IContext.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MvcApplication2.Entities.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IContext
    {
        IDbSet<Application> Applications { get; set; }

        int SaveChanges();
    }
}
