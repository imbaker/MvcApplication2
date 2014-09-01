// -----------------------------------------------------------------------
// <copyright file="InMemoryCategoryRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MvcApplication2.Tests.Database.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class InMemoryCategoryRepository : MvcApplication2.Database.Repositories.Interfaces.ICategoryRepository
    {


        public void Insert(MvcApplication2.Database.Entities.Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(MvcApplication2.Database.Entities.Category entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MvcApplication2.Database.Entities.Category> SearchFor(System.Linq.Expressions.Expression<Func<MvcApplication2.Database.Entities.Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MvcApplication2.Database.Entities.Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public MvcApplication2.Database.Entities.Category GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
