namespace System.Collections.Generic
{
    /// <summary>Abstrai as fun��es necessarias para comparar dois objetos</summary>
    /// <typeparam name="T"></typeparam>
    public class GenericComparer<T> : IEqualityComparer<T>, IEqualityComparer

    {
        private readonly Func<T, T, bool> _equality;

        private readonly Func<T, int> _hashCode;

        /// <summary></summary>
        /// <param name="equality">Fun��o que determina se dois objetos s�o iguais</param>
        /// <param name="hashCode">Fun��o que gerar o HashCode do objeto</param>
        public GenericComparer(Func<T, T, bool> equality, Func<T, int> hashCode)
        {
            if (equality == null)
                throw new ArgumentNullException(nameof(equality), "N�o foi definido uma fun��o valida para comparar os objetos");
            if (hashCode == null)
                throw new ArgumentNullException(nameof(hashCode), "N�o foi definido uma fun��o valida para obter o hashCode");
            _equality = equality;
            _hashCode = hashCode;
        }

        /// <summary>Determina se dois objetos s�o iguais</summary>
        /// <param name="x">Primeiro objeto que ser� verificado</param>
        /// <param name="y">Segundo objeto</param>
        /// <returns>Retorna verdadeiro se ambos os objetos forem iguais</returns>
        public bool Equals(T x, T y)
        {
            return _equality(x, y);
        }

        /// <summary> Returns a hash code for the specified object.</summary>
        /// <returns></returns>
        public int GetHashCode(T obj)
        {
            return _hashCode(obj);
        }

        bool IEqualityComparer.Equals(object x, object y)
        {
            return Equals((T)x, (T)y);
        }

        int IEqualityComparer.GetHashCode(object obj)
        {
            return GetHashCode((T)obj);
        }


    }
}