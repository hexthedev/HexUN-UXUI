using UnityEngine;
using HexCS.Core;
using HexUN.Events;

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

        [SerializeField]
        protected bool _forceActive = false;

        #region API
        /// <summary>
        /// Is this button forced active? Meaning it will no longer respond to click events
        /// and will show as active in the view. 
        /// </summary>
        public bool ForceActive
        {
            get => _forceActive;
            set
            {
                if (_forceActive != value) _forceActive = value;
                RenderView();
            }
        }

        /// <inheritdoc />
        public bool IsInteractable => _interactable;

        /// <inheritdoc />
        public IEventSubscriber OnClick => _onClick;

        /// <inheritdoc />
        public IEventSubscriber<bool> OnInteractionState => _onInteractationState;

        public virtual void Click()
        {
            if (ForceActive) return;
            _onClick.Invoke();
        }

        /// <inheritdoc />
        public void SetInteractable(bool interactable)
        {
            if (_interactable == interactable) return;
            _interactable = interactable;
            _view?.Render();
            _onInteractationState.Invoke(_interactable);
        }
        #endregion

        protected override void OnValidate()
        {
            _onInteractationState.Invoke(_interactable);
            _view?.Initialize();
        }
    }
}