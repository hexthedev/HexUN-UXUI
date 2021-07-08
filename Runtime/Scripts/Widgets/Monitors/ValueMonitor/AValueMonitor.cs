using HexUN.Sub.UIUX.Framework;
using HexUN.Utilities;

namespace HexUN.Sub.UIUX.ProtoUi
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
            get => _value.Value;
            set => _value.Value = value;
        }


        /// <inheritdoc />
        protected override void HexAwake()
        {
            _value = MakeFrequentVar<T>(default);
        }

        /// <inheritdoc />
        protected override void HandleFrequentRender()
        {
            HandleValueRender( GetFrequent(ref _value) );
        }

        /// <summary>
        /// Implementation of value rendering
        /// </summary>
        protected abstract void HandleValueRender(T value);
    }
}