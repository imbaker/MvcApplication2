using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication2.Tests.Database.Repositories
{
    using MvcApplication2.Database.Entities.Interfaces;
    using MvcApplication2.Database.Repositories.Interfaces;

    class Repository<T> : IRepository<T> where T : class
    {
        private IContext context;

        private bool disposed;

        protected Repository(IContext context)
        {
            this.context = context;
            this.disposed = false;
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
