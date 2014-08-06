// -----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MvcApplication2.Database.Repositories.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
