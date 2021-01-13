using System;

namespace HexUN.UXUI
{
    /// <summary>
    /// Allows data to be pulled
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataToken<T>
    {
        event Action OnValueChange; 

        T Value { get; }
    }
}
