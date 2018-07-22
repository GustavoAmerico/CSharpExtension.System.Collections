using System.Linq.Expressions;
// ReSharper disable CheckNamespace

namespace System.Linq
{
    /// <summary>Extensions for Queryble collections</summary>
    public static class QueryableExtensions
    {

        /// <summary>Filters a sequence of values based on a predicate and projects each element of a sequence into a new form.</summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult"> The type of the value returned by the function represented by selector</typeparam>
        /// <param name="collection">An <paramref name="collection"/> to filter.</param>
        /// <param name="condition">A function to test each element for a condition.</param>
        /// <param name="selector"> A projection function to apply to each element.</param>
        /// <returns>An list whose elements are the result of invoking a projection function on each element of source and satisfy the condition specified by predicate.</returns>
        public static IQueryable<TResult> Where<T, TResult>(this IQueryable<T> collection, Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> selector)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            var x = collection.Where(condition).Select(selector);
            return x;
        }

        /// <summary>Filters a sequence of values based on a predicate and projects each element of a sequence into a new form.</summary>
        /// <param name="collection">An <paramref name="collection"/> to filter.</param>
        /// <param name="condition">A function to test each element for a condition.</param>
        /// <param name="selector"> A projection function to apply to each element.</param>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult"> The type of the value returned by the function represented by selector</typeparam>
        /// <returns>An array whose elements are the result of invoking a projection function on each element of source and satisfy the condition specified by predicate.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TResult[] ToArray<T, TResult>(this IQueryable<T> collection, Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> selector)
        {

            if (condition == null) throw new ArgumentNullException(nameof(condition));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            var x = collection.Where(condition)
                .Select(selector)
                .ToArray();
            return x;
        }

        /// <summary>Filters a sequence of values based on a predicate and projects each element of a sequence into a new form.</summary>
        /// <param name="collection">An <paramref name="collection"/> to filter.</param>
        /// <param name="condition">A function to test each element for a condition.</param>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <returns>An array whose elements are the result of invoking a projection function on each element of source and satisfy the condition specified by predicate.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T[] ToArray<T>(this IQueryable<T> collection, Expression<Func<T, bool>> condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));
            var x = collection.Where(condition).ToArray();
            return x;
        }

        /// <summary>Filters a sequence of values based on a predicate and projects each element of a sequence into a new form.</summary>
        /// <param name="collection">An <paramref name="collection"/> to filter.</param>
        /// <param name="condition">A function to test each element for a condition.</param>
        /// <param name="func"></param>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <typeparam name="TCollection"></typeparam>
        /// <returns>An array whose elements are the result of invoking a projection function on each element of source and satisfy the condition specified by predicate.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TCollection To<T, TCollection>(
            this IQueryable<T> collection,
            Expression<Func<T, bool>> condition) where TCollection : EnumerableQuery<T>
        {

            if (condition == null) throw new ArgumentNullException(nameof(condition));
            var x = collection.Where(condition);
            var y = (TCollection)new EnumerableQuery<T>(x);
            return y;
        }


    }
}
