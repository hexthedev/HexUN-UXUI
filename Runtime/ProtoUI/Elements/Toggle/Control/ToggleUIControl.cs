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
    public class ToggleUIControl : MonoEnhanced, IToggleUIControl
    {
        [Header("View")]
        [SerializeField]
        private AToggleUIView _view = null;

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
            if (_view != null) _view.HandleInteractionState(interactable);
            _interactable = interactable;
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
        protected void OnValidate()
        {
            _view.Initialize(_interactable, _toggleState);
            _onInteractationState?.Invoke(_interactable);
            _onToggleState?.Invoke(_toggleState);
        }

        private void SetState(bool state)
        {
            if (_toggleState == state) return;
            if(_view != null) _view.HandleToggleState(state);
            _toggleState = state;
            _onToggleState.Invoke(_toggleState);
        }
    }
}