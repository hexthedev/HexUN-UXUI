using HexUN.Events;
using HexUN.Sub.UIUX.Framework;
using HexUN.Utilities;

using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Provides a <see cref="ToggleState"/> occasional variable for rendering
    /// toggle like ui elements
    /// </summary>
    public abstract class AGuiToggleBehaviour : AGuiRenderBehaviour
    {
        [Header("[AGuiToggleBehaviour]")]
        [Header("Actions")]
        [SerializeField]
        private BooleanReliableEvent _onToggleStateChanged = new BooleanReliableEvent();

        [SerializeField]
        private bool _defaultToggleState;

        private OnChangeVariable<bool> pToggleState;

        #region API
        /// <summary>
        /// Get or set the state of the toggle to a specific value
        /// </summary>
        public bool ToggleState {
            get => GetOccasional(ref pToggleState);
            set
            {
                bool changed = value != ToggleState;
                SetOccasional(ref pToggleState, value);
                if (changed) _onToggleStateChanged?.Invoke(ToggleState);
            }
        }

        /// <inheritdoc />
        public void Toggle() => ToggleState = !ToggleState;
        #endregion

        /// <inheritdoc />
        protected override void HexAwake()
        {
            CallAfterStart(o => ToggleState = _defaultToggleState);
        }

        /// <inheritdoc />
        protected void OnValidate()
        {
            ToggleState = _defaultToggleState;
        }
    }
}