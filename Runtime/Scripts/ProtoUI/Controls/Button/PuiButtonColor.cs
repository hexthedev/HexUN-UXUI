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
    public class PuiButtonColor : APuiButton
    {
        [Header("Dependencies (Rendering)")]
        [SerializeField]
        private Image _image = default;

        [SerializeField]
        private GameColorScheme _colorScheme = default;

        [Header("Options (Rendering)")]
        [SerializeField]
        [Tooltip("What is the neutral color when not being clicked")]
        private ESchemeColor _SchemeColor = ESchemeColor.Primary;

#if HEXDB
        [Header("Debugging (Rendering)")]
        [SerializeField]
#endif
        private GameColor _resolvedGameColor = default;

        [Header("State (Rendering)")]
        [SerializeField]
        private EHoverableEvent _hoverState = default;

        protected override void MonoAwake()
        {
            base.MonoAwake();
            ResolveColorReferences();
        }
        
        public override void Initialize() => ResolveColorVisuals();

        /// <summary>
        /// Handle visual changes that occur when hover events are fired
        /// </summary>
        /// <param name="interactionState"></param>
        public void HandleHoverableEvent(EHoverableEvent hover)
        {
            _hoverState = hover;
            Render();
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            ResolveColorReferences();
            ResolveColorVisuals();
        }

        private void ResolveColorReferences()
        {
            _resolvedGameColor = _colorScheme.GetGameColor(_SchemeColor);
        }

        private void ResolveColorVisuals()
        {
            if (ForceActive)
            {
                _image.color = _resolvedGameColor.Light;
                return;
            }

            if (!Interactable)
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

        protected override void HandleFrameRender() => ResolveColorVisuals();
    }
}