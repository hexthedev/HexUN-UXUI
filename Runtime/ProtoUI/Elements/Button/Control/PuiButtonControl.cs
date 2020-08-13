using UnityEngine;
using HexCS.Core;
using HexUN.Events;
using HexUN.MonoB;

namespace HexUN.UXUI
{
    public class PuiButtonControl : APuiControl<APuiButtonView>
    {
        [Header("View")]
        [SerializeField]
        private APuiButtonView _view;

        [Header("Emissions (AButtonUIControl)")]
        [SerializeField]
        protected VoidReliableEvent _onClick = new VoidReliableEvent();

        [SerializeField]
        private BooleanReliableEvent _onInteractationState = new BooleanReliableEvent();

        [Header("Debug (AButtonUIControl)")]
        [SerializeField]
        private bool _interactable = false;

        /// <inheritdoc />
        public bool IsInteractable => _interactable;

        /// <inheritdoc />
        public IEventSubscriber OnClick => _onClick;

        /// <inheritdoc />
        public IEventSubscriber<bool> OnInteractionState => _onInteractationState;

        public virtual void Click() => _onClick.Invoke();

        /// <inheritdoc />
        public void SetInteractable(bool interactable)
        {
            if (_interactable == interactable) return;
            _interactable = interactable;
            _view?.Render();
            _onInteractationState.Invoke(_interactable);
        }

        private void OnValidate()
        {
            _onInteractationState.Invoke(_interactable);
            _view?.Initialize();
        }
    }
}