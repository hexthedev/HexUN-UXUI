using HexUN.Design;
using HexUN.Input;
using HexUN.Behaviour;
using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    /// <summary>
    /// Toggles the color of a text and an image using Hoverable interaction events
    /// </summary>
    public class PuiButtonSprite : APuiButton
    {
        [Header("Dependencies (Button)")]
        [SerializeField]
        private Image _image = default;

        [Header("Options (Button)")]
        [SerializeField]
        [Tooltip("What is the neutral color when not being clicked")]
        private SpriteArgs _spriteArgs = null;

        [Header("State (Button)")]
        [SerializeField]
        private EHoverableEvent _hoverState = EHoverableEvent.Absent;

        #region API
        /// <summary>
        /// Sprites args used to render the button
        /// </summary>
        public SpriteArgs SpriteArgs
        {
            get => _spriteArgs;
            set
            {
                if (_spriteArgs == value) return;
                _spriteArgs = value;
                Render();
            }
        }

        /// <summary>
        /// Hover state of the button
        /// </summary>
        public EHoverableEvent HoverState
        {
            get => _hoverState;
            set
            {
                if (_hoverState == value) return;
                _hoverState = value;
                Render();
            }
        }
        public override void Initialize() => HandleFrameRender();
        #endregion

        protected override void HandleFrameRender()
        {
            if(_spriteArgs == null)
            {
                _image.enabled = false;
                return;
            }

            if (ForceActive)
            {
                _spriteArgs.ApplyToImage(_image, EUiVisualState.Neutral);
                return;
            }

            if (!Interactable)
            {
                _spriteArgs.ApplyToImage(_image, EUiVisualState.Disabled);
            }
            else
            {
                if(UTEUiVisualState.TryFromEHoverableEvent(_hoverState, out EUiVisualState state))
                {
                    _spriteArgs.ApplyToImage(_image, state);
                }
                else
                {
                    _spriteArgs.ApplyToImage(_image, EUiVisualState.Neutral);
                }
            }
        }
    }
}