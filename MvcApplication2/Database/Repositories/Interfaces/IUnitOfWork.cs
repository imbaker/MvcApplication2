// -----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MvcApplication2.Database.Repositories.Interfaces
{
    using System;

    using MvcApplication2.Database.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IUnitOfWork : IDisposable 
    {
        IRepository<Application> ApplicationRepository { get; }

        IRepository<Category> CategoryRepository { get; }

        void Save();
    }
}
