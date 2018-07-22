using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace System.Linq
{/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
    public interface IQueryableCollection<T> : IQueryable<T>, ICollection<T>
    {
        /// <summary> Adds an item to the collection</summary>
        /// <param name="itens">item to be added</param>
        void Add(params T[] itens);

    }
}
