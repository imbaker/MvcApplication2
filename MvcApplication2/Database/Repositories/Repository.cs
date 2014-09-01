using System;
using System.Linq;

namespace MvcApplication2.Database.Repositories
{
    using System.Data.Entity;

    using MvcApplication2.Database;
    using MvcApplication2.Database.Repositories.Interfaces;

    class Repository<T> : IRepository<T> where T : class
    {
        private bool disposed;
        private Db Context;

        private DbSet<T> dbSet;

        public Repository(Db context)
        {
            this.Context = context;
            this.dbSet = Context.Set<T>();
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
            return Context.Set<T>();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
