// -----------------------------------------------------------------------
// <copyright file="MemoryRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MvcApplication2.Tests.Database.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects.DataClasses;
    using System.Linq;
    using System.Text;

    using MvcApplication2.Database.Repositories.Interfaces;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MemoryRepository<E> : IRepository<E>
    {
        protected readonly List<E> objectSet = new List<E>();

        public virtual IQueryable<E> GetAll()
        {
            return objectSet.AsQueryable();
        }

        public void Insert(E entity)
        {
            objectSet.Add(entity);
        }

        public void Delete(E entity)
        {
            objectSet.Remove(entity);
        }

        public IQueryable<E> SearchFor(System.Linq.Expressions.Expression<Func<E, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public E GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
