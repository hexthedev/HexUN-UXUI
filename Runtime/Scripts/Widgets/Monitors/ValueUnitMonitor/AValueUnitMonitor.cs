using HexUN.Sub.UIUX.Framework;
using HexUN.Utilities;

namespace HexUN.Sub.UIUX.ProtoUi
{
    public abstract class AValueUnitMonitor<TValue, TUnit> : GuiRenderBehaviour
    {
        private OnChangeVariable<TValue> _value;
        private OnChangeVariable<TUnit> _unit;

        /// <summary>
        /// The value to display
        /// </summary>
        public TValue Value { get => GetContent(ref _value); set => SetContent(ref _value, value); }
        
        /// <summary>
        /// The Unit to display
        /// </summary>
        public TUnit Unit { get => GetStyle(ref _unit); set => SetStyle(ref _unit); }

        protected override void HexAwake()
        {
            _value = MakeContentVar<TValue>();
            _unit = MakeStyleVar<TUnit>();
        }

        protected override void HandleContentRender()
        {
            HandleValueChange(Value);
        }

        protected abstract void HandleValueChange(TValue value);

        protected override void HandleStyleRender()
        {
            HandleUnitChange(Value);
        }

        protected abstract void HandleUnitChange(TValue value);
    }
}