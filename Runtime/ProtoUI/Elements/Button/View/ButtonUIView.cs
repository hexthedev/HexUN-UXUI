using HexUN.Design;
using HexUN.Input;
using HexUN.MonoB;
using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    /// <summary>
    /// Toggles the color of a text and an image using Hoverable interaction events
    /// </summary>
    public class ButtonUIView : MonoEnhanced
    {
        [Header("Dependencies (ButtonUIViewHoverColor)")]
        [SerializeField]
        private Image _image = default;

        [SerializeField]
        private GameColorScheme _colorScheme = default;

        [Header("Options (ButtonUIViewHoverColor)")]
        [SerializeField]
        [Tooltip("What is the neutral color when not being clicked")]
        private ESchemeColor _SchemeColor = ESchemeColor.Primary;

        [Header("Debugging (ToggleUIViewHoverColor)")]
        [SerializeField]
        private GameColor _resolvedGameColor = default;

        [Header("View State")]
        [SerializeField]
        private EHoverableEvent _hoverState = default;

        [SerializeField]
        private bool _interactable = default;

        private bool _changedThisFrame = false;

        protected override void MonoAwake()
        {
            base.MonoAwake();
            ResolveColorReferences();
        }
        
        public void Initialize(bool interactionState)
        {
            _interactable = interactionState;
            ResolveColorVisuals();
        }

        /// <summary>
        /// Handle visual changes that occur when hover events are fired
        /// </summary>
        /// <param name="interactionState"></param>
        public void HandleHoverableEvent(EHoverableEvent hover)
        {
            _hoverState = hover;
            HandleFrameChange();
        }

        /// <summary>
        /// Handle visual changes that occur when the state of the interactablility changes
        /// </summary>
        /// <param name="interactionState"></param>
        public void HandleInteractionState(bool interactionState)
        {
            _interactable = interactionState;
            HandleFrameChange();
        }

        protected void OnValidate()
        {
            ResolveColorReferences();
            ResolveColorVisuals();
        }
        private void Update()
        {
            if (_changedThisFrame) ResolveColorVisuals();
        }

        private void ResolveColorReferences()
        {
            _resolvedGameColor = _colorScheme.GetGameColor(_SchemeColor);
        }

        private void ResolveColorVisuals()
        {
            if (!_interactable)
            {
                _image.color = _resolvedGameColor.Greyed;
            }
            else
            {
                switch (_hoverState)
                {
                    case EHoverableEvent.Down:
                        _image.color = _resolvedGameColor.Light;
                        break;
                    case EHoverableEvent.Absent:
                        _image.color = _resolvedGameColor.Base;
                        break;
                    case EHoverableEvent.Hovering:
                        _image.color = _resolvedGameColor.Dark;
                        break;
                }
            }
        }

        private void HandleFrameChange()
        {
            if (IsStarted) _changedThisFrame = true;
            else ResolveColorVisuals();
        }
    }
}