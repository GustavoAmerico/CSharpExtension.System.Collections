using System.Collections.Generic;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace

namespace System.Linq
{
    /// <summary>Container for Queryable provider from T</summary>
    /// <typeparam name="T">type of elements from provider</typeparam>
    public class QueryableCollection<T> : BaseCollection<T>, IQueryableCollection<T>
    {
        private readonly IQueryable<T> _queryable;

        /// <summary>
        /// Gets the type of the element(s) that are returned when the expression tree associated
        /// with this instance of System.Linq.IQueryable is executed.
        /// </summary>
        public Type ElementType => _queryable.ElementType;

        /// <summary>Gets the expression tree that is associated with the instance of System.Linq.IQueryable</summary>
        public Expression Expression => _queryable.Expression;

        /// <summary>Gets the query provider that is associated with this data source.</summary>
        public IQueryProvider Provider => _queryable.Provider;

        /// <summary>Initialize an container for new Queryable provider</summary>
        public QueryableCollection()
        {
            _queryable = new EnumerableQuery<T>(Itens);
             
        }

        /// <summary>Initialize an container for exist Queryable provider</summary>
        public QueryableCollection(IQueryableCollection<T> queryable) : base(queryable)
        {
             
            _queryable = queryable;
        }

        /// <summary></summary>
        /// <param name="itens"></param>
        public QueryableCollection(ICollection<T> itens) : base(itens)
        {
            _queryable = (itens as IQueryable<T>) ?? new EnumerableQuery<T>(itens);
        }

        /// <summary>Adds an item to the collection</summary>
        /// <param name="itens">item to be added</param>
        public void Add(params T[] itens)
        {
            if (itens.IsEmpty())
                return;
            foreach (var item in itens.Where(item => item != null))
                base.Add(item);
        }
    }
}