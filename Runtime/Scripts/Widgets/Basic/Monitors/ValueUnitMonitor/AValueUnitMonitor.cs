using HexUN.Sub.UIUX.Framework;
using HexUN.Utilities;

namespace HexUN.Sub.UIUX.ProtoUi
{
    public abstract class AValueUnitMonitor<TValue, TUnit> : AGuiRenderBehaviour
    {
        private OnChangeVariable<TValue> _value;
        private OnChangeVariable<TUnit> _unit;

        /// <summary>
        /// The value to display
        /// </summary>
        public TValue Value { get => GetFrequent(ref _value); set => SetFrequent(ref _value, value); }
        
        /// <summary>
        /// The Unit to display
        /// </summary>
        public TUnit Unit { get => GetOccasional(ref _unit); set => SetOccasional(ref _unit); }

        protected override void HexAwake()
        {
            _value = MakeFrequentVar<TValue>();
            _unit = MakeOccasionalVar<TUnit>();
        }

        protected override void HandleFrequentRender()
        {
            HandleValueChange(Value);
        }

        protected abstract void HandleValueChange(TValue value);

        protected override void HandleOccasionalRender()
        {
            HandleUnitChange(Value);
        }

        protected abstract void HandleUnitChange(TValue value);
    }
}