namespace System.Collections.Generic
{
    /// <summary>
    /// Exposes the enumerator, which supports a simple iteration over a collection of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of objects to enumerate</typeparam>
    public class BaseEnumerable<T> : IEnumerable<T>
    {
        /// <summary>Itens of Enumerable</summary>
        private readonly IEnumerable<T> _itens;

        /// <summary>Itens of Enumerable</summary>
        protected virtual IEnumerable<T> Itens { get; private set; }

        /// <summary>Initialize an enumerable container for type element</summary>
        public BaseEnumerable() : this(new T[0])
        {

        }

        /// <summary>encapsulates an existing enumerator</summary>
        /// <param name="itens">existing enumerator</param>
        public BaseEnumerable(IEnumerable<T> itens)
        {
            _itens = itens;
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate
        /// through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _itens.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}