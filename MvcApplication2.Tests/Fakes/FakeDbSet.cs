// -----------------------------------------------------------------------
// <copyright file="FakeDbSet.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MvcApplication2.Tests.Fakes
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        HashSet<T> _data;
        IQueryable _query;

        public FakeDbSet()
        {
            _data = new HashSet<T>();
            _query = _data.AsQueryable();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }
        public void Add(T item)
        {
            _data.Add(item);
        }

        public void Remove(T item)
        {
            _data.Remove(item);
        }

        public void Attach(T item)
        {
            _data.Add(item);
        }
        public void Detach(T item)
        {
            _data.Remove(item);
        }
        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }
        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        T IDbSet<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }

        T IDbSet<T>.Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(_data); }
        }

        T IDbSet<T>.Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
