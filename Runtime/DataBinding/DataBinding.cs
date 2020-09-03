using System;

namespace HexUN.UXUI
{
    /// <summary>
    /// Data tokens contain a function that pulls a value, so that UI elements
    /// can be bound to a single source of data
    /// </summary>
    public class DataBinding<T> : IDataToken<T>
    {
        private Func<T> _valueFunction;

        #region API
        /// <summary>
        /// Invoked when value is changed
        /// </summary>
        public event Action OnValueChange;

        /// <summary>
        /// Get the current data value
        /// </summary>
        public T Value => _valueFunction == null ? default : _valueFunction();

        /// <summary>
        /// Constructor
        /// </summary>
        public DataBinding(Func<T> valueFunction)
        {
            _valueFunction = valueFunction;
        }

        /// <summary>
        /// It is up to an outside manager to detect when change occurs. Using prompt OnChange
        /// notifies listeners that the data has changed
        /// </summary>
        public void PromptChange()
        {
            _valueFunction?.Invoke();
        }
        #endregion
    }
}
