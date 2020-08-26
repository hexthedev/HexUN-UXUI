using HexUN.Events;
using UnityEngine;

namespace HexUN.UXUI
{
    public abstract class APuiToggleControl : APuiControl
    {
        [Header("Actions (Toggle)")]
        [SerializeField]
        private BooleanReliableEvent _onToggleState = new BooleanReliableEvent();

#if HEXDB
        [Header("Debug")]
        [SerializeField]
#endif
        protected bool _toggleState = false;

#region API
        /// <summary>
        /// Get or set the state of the toggle
        /// </summary>
        public bool ToggleState => _toggleState;

        /// <inheritdoc />
        public void Toggle() => SetState(!ToggleState);

        /// <inheritdoc />
        public void ForceToggle(bool state) => SetState(state);
#endregion

        /// <inheritdoc />
        protected override void MonoStart()
        {
            CallAfterStart(o => SetState(_toggleState));
        }

        /// <inheritdoc />
        protected override void OnValidate()
        {
            base.OnValidate();
            _onToggleState?.Invoke(_toggleState);
        }

        private void SetState(bool state)
        {
            if (_toggleState == state) return;
            _toggleState = state;
            Render();
            _onToggleState.Invoke(_toggleState);
        }
    }
}