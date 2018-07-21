using System.Linq;

namespace System.Collections.Generic
{
    /// <summary></summary>
    public static class EnumerableExtensions
    {
        /// <summary>Checks if the list is null or empty</summary>
        /// <returns>Return true if it is null OR no have item</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable) =>
            ReferenceEquals(enumerable, null) || !enumerable.Any();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TCollection"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="selector"></param>
        /// <param name="constructor"></param>
        /// <returns></returns>
        public static TCollection Select<T, TResult, TCollection>(
            this IEnumerable<T> enumerable,
             Func<T, TResult> selector,
            Func<IEnumerable<TResult>, TCollection> constructor)
        {
                if (constructor == null) throw new ArgumentNullException(nameof(constructor));

            if (enumerable.IsEmpty())
                return constructor(new TResult[0]);
            var x = enumerable.Select(selector);
            return constructor(x);
        }

        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="expression"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Where<T, TResult>(
            this IEnumerable<T> enumerable,
            Func<T, bool> expression,
            Func<T, TResult> selector)
        {
            if (enumerable.IsEmpty())
                return new TResult[0];

            return enumerable
                .Where(expression)
                .Select(selector);
        }
 
    }
}
