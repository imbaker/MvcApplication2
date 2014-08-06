using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Database.Repositories
{
    using MvcApplication2.Database.Entities;
    using MvcApplication2.Database.Repositories.Interfaces;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly Db Context;
        private readonly IRepository<Application> ApplicationRepository; 
        private readonly IRepository<Category> CategoryRepository;

        public UnitOfWork(Db context)
        {
            this.Context = context;
        }
 
        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        IRepository<Entities.Application> IUnitOfWork.ApplicationRepository
        {
            get { return ApplicationRepository; }
        }

        IRepository<Entities.Category> IUnitOfWork.CategoryRepository
        {
            get { return CategoryRepository; }
        }
    }
}