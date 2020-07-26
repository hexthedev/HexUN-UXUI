using UnityEngine;
using HexCS.Core;
using HexUN.Events;
using HexUN.MonoB;

namespace HexUN.UXUI
{
    public class ButtonUIControl : MonoEnhanced, IButtonUIControl
    {
        [Header("View")]
        [SerializeField]
        private ButtonUIView _view;

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
            if(_view != null) _view.HandleInteractionState(interactable);
            _onInteractationState.Invoke(_interactable);
        }

        private void OnValidate()
        {
            _onInteractationState.Invoke(_interactable);
            if (_view != null) _view.Initialize(_interactable);
        }
    }
}