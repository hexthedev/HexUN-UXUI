using HexCS.Core;
using HexUN.Deps;
using HexUN.Events;
using HexUN.MonoB;
using HexUN.Patterns;
using HexUN.Work;
using HexUN.Input;
using UnityEngine;

namespace HexUN.UXUI
{
    public class PuiToggleControl : APuiControl<APuiToggleView>
    {
        [Header("Emissions")]
        [SerializeField]
        private BooleanReliableEvent _onToggleState = new BooleanReliableEvent();

        [SerializeField]
        private BooleanReliableEvent _onInteractationState = new BooleanReliableEvent();

        [Header("Debug")]
        [SerializeField]
        private bool _toggleState = false;

        [SerializeField]
        private bool _interactable = false;

        #region API
        /// <summary>
        /// Get or set the state of the toggle
        /// </summary>
        public bool ToggleState => _toggleState;

        /// <inheritdoc />
        public bool IsInteractable => _interactable;

        /// <inheritdoc />
        public void SetInteractable(bool interactable)
        {
            if (_interactable == interactable) return;
            _interactable = interactable;
            View?.Render();
            _onInteractationState.Invoke(_interactable);
        }

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
            if (View == null) View = gameObject.GetComponent<APuiToggleView>();

            View?.Initialize();
            _onInteractationState?.Invoke(_interactable);
            _onToggleState?.Invoke(_toggleState);
        }

        private void SetState(bool state)
        {
            if (_toggleState == state) return;
            _toggleState = state;
            View?.Render();
            _onToggleState.Invoke(_toggleState);
        }
    }
}