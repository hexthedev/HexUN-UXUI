using HexUN.Sub.UIUX.Framework;
using HexUN.Utilities;

namespace HexUN.Sub.UIUX.Widgets
{
    /// <summary>
    /// UiElement that renders a single value
    /// </summary>
    public abstract class AValueMonitor<T> : AGuiRenderBehaviour
    {
        private OnChangeVariable<T> _value;

        /// <summary>
        /// The value being montiored
        /// </summary>
        public T Value
        {
            get => GetFrequent(ref _value);
            set => SetFrequent(ref _value, value);
        }

        /// <inheritdoc />
        protected override void HandleFrequentRender() => HandleValueRender( Value );
        
        /// <summary>
        /// Implementation of value rendering
        /// </summary>
        protected abstract void HandleValueRender(T value);
    }
}