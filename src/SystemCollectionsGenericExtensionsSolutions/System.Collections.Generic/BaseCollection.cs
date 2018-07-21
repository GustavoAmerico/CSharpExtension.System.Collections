namespace System.Collections.Generic
{
    /// <summary>Exposes the enumerator, which supports a simple iteration over a collection of a specified type.</summary>
    /// <typeparam name="T">The type of objects to enumerate</typeparam>
    public   class BaseCollection<T> : BaseEnumerable<T>, ICollection<T>
    {
        /// <summary>Gets the number of elements</summary>
        public int Count => _collection.Count;

        /// <summary>Gets a value indicating whether is read-only.</summary>
        public virtual bool IsReadOnly => _collection.IsReadOnly;

        private readonly ICollection<T> _collection;

        /// <summary>create an enumerable hashset for type element</summary>
        protected BaseCollection() : this(new HashSet<T>())
        {
              
        }

        /// <summary>create an enumerable for type element</summary>
        protected BaseCollection(ICollection<T> list) : base(list)
        {
            _collection = list;
        }

        /// <summary>Adiciona o item junto da coleção</summary>
        /// <param name="item">item a ser adicionado</param>
        /// <returns>retorna true se o item foi adicionado se não false</returns>
        public virtual void Add(T item) => _collection.Add(item);

        /// <summary>Remove all itens</summary>
        protected virtual void Clear() => _collection.Clear();

        /// <summary>Determine if this container specific value</summary>
        /// <param name="item">value its validation</param>
        /// <returns>returns true if exists</returns>
        public bool Contains(T item) => _collection.Contains(item);

        /// <summary>Copies the elements of the Collection to an System.Array,
        ///     starting at a particular System.Array index.</summary>
        /// <param name="array"> the destination of the elements copied</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        void ICollection<T>.Clear() => Clear();

        /// <summary> Removes the first occurrence of a specific object </summary>
        /// <param name="item">The object to remove </param>
        /// <returns>true if item was successfully removed otherwise, false.</returns>
        /// <remarks>This method also returns false if item is not found</remarks>
        public virtual bool Remove(T item) => _collection.Remove(item);
    }
}