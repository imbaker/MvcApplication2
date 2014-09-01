using System;

namespace MvcApplication2.Database.Repositories
{
    using MvcApplication2.Database.Entities;
    using MvcApplication2.Database.Repositories.Interfaces;
    using MvcApplication2.Database.Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly Db Context;
        private IRepository<Application> ApplicationRepository; 
        private IRepository<Category> CategoryRepository;

        public UnitOfWork(Db context)
        {
            this.Context = context;
        }
 
        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        IRepository<Entities.Application> IUnitOfWork.ApplicationRepository
        {
            get
            {
                return ApplicationRepository ?? new Repository<Application>(Context);
            }
        }

        IRepository<Entities.Category> IUnitOfWork.CategoryRepository
        {
            get
            {
                return CategoryRepository ?? new Repository<Category>(Context);
            }
        }
    }
}