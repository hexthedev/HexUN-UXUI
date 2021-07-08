using HexUN.Design;
using HexUN.Input;
using HexUN.Utilities;
using HexUN.UXUI;

using UnityEngine;
using UnityEngine.UI;

namespace HexUN.Sub.UIUX
{
    /// <summary>
    /// Toggles the color of a text and an image using Hoverable interaction events
    /// </summary>
    public class GuiButton_Color : AGuiButtonBehaviour
    {
        [Header("[GuiButton_Color]")]
        [SerializeField] private Image _image = default;

        [Header("RenderOptions")]
        [SerializeField] private Color _neutral;
        [SerializeField] private Color _hover;
        [SerializeField] private Color _down;
        [SerializeField] private Color _disabled;
        [SerializeField] private Color _highlighted;

        private OnChangeVariable<EUiVisualState> _visualState;

        private bool _interactable;
        private EHoverableEvent _hoverEvent;
        private EPointerEvent _pointerEvent;

        private void Awake()
        {
            SetOccasional(ref _visualState, EUiVisualState.Neutral);
            ResolveVisualState();
        }

        protected void OnValidate()
        {
            SetOccasional(ref _visualState, EUiVisualState.Neutral);
            ResolveVisualState();
        }

        /// <summary>
        /// Handle visual changes that occur when hover events are fired
        /// </summary>
        /// <param name="interactionState"></param>
        public void HandleHoverableEvent(EHoverableEvent hover)
        {
            _hoverEvent = hover;
            ResolveVisualState();
        }

        public void HandlePointerEvent(EPointerEvent pointer){
            if (pointer == EPointerEvent.Click) _onClick.Invoke();
        }

        public void HandleInteractableEvent(bool interactable)
        {
            _interactable = interactable;
            ResolveVisualState();
        }

        private void ResolveVisualState()
        {
            // If not interactable, disabled
            if (!_interactable)
            {
                SetOccasional(ref _visualState, EUiVisualState.Disabled);
                return;
            }

            // if not hovering then neutral
            if (UTEUiVisualState.TryFromEHoverableEvent(_hoverEvent, out EUiVisualState state))
                SetOccasional(ref _visualState, state);
        }

        protected override void HandleOccasionalRender()
        {
            switch (GetOccasional(ref _visualState))
            {
                case EUiVisualState.Disabled:
                    _image.color = _disabled;
                    break;
                case EUiVisualState.Down:
                    _image.color = _down;
                    break;
                case EUiVisualState.Highlighted:
                    _image.color = _highlighted;
                    break;
                case EUiVisualState.Hover:
                    _image.color = _hover;
                    break;
                case EUiVisualState.Neutral:
                    _image.color = _neutral;
                    break;
            }
        }

        protected override void HandleFrequentRender() { }
    }
}