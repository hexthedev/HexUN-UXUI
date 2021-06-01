using TMPro;
using HexUN.Design;
using HexUN.Input;
using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    /// <summary>
    /// Toggles the color of a text and an image using Hoverable interaction events
    /// </summary>
    public class PuiToggleHoverColor : APuiToggle
    {
        [Header("Dependencies (ToggleUIViewHoverColor)")]
        [SerializeField]
        private TextMeshProUGUI _text = default;

        [SerializeField]
        private Image _image = default;

        [SerializeField]
        private GameColorScheme _colorScheme = default;

        [Header("Options (ToggleUIViewHoverColor)")]
        [SerializeField]
        [Tooltip("What colors does the text follow. Text will always use base color")]
        private ESchemeColor _textSchemeColor = ESchemeColor.Neutral;

        [SerializeField]
        [Tooltip("What colors does the background follow in On state. Hover is lighted, clicked is darker")]
        private ESchemeColor _backgroundSchemeColorOn = ESchemeColor.Primary;

        [SerializeField]
        [Tooltip("What colors does the background follow in Off state. Hover is lighted, clicked is darker")]
        private ESchemeColor _backgroundSchemeColorOff = ESchemeColor.Secondary;

#if HEXDB
        [Header("Debugging (ToggleUIViewHoverColor)")]
        [SerializeField]
#endif
        private GameColor _textColor = default;

#if HEXDB
        [SerializeField]
#endif
        private GameColor _backgroundColorOn = default;

#if HEXDB
        [SerializeField]
#endif
        private GameColor _backgroundColorOff = default;

        [Header("View State")]
        [SerializeField]
        private bool _isHovering = default;

#region Protected API
        protected override void HexAwake()
        {
            base.HexAwake();
            ResolveColorReferences();
        }

        protected override void HexStart()
        {
            base.HexStart();
            CallAfterStart(o => RenderAll());
        }

        protected void OnValidate()
        {
            ResolveColorReferences();
            ResolveColorVisuals();
        }
#endregion

#region Public API
        /// <summary>
        /// Handle hover events
        /// </summary>
        /// <param name="hover"></param>
        public void HandleHoverableEvent(EHoverableEvent hover)
        {
#if HEXDB
            if (Log != null) Log.Invoke($"${gameObject.name}:{nameof(ToggleUIViewHoverColor)} received hover event {hover}");
#endif
            if(hover != EHoverableEvent.Down) // toggle doesn't react to down
            {
                _isHovering = hover == EHoverableEvent.Hovering;

                if (!IsStarted) ResolveColorReferences();
                else RenderAll();
            }
        }

        public override void Initialize()
        {
            ResolveColorVisuals();
        }
#endregion

        protected override void HandleStyleRender() => ResolveColorVisuals();

        private void ResolveColorReferences()
        {
            _textColor = _colorScheme.GetGameColor(_textSchemeColor);
            _backgroundColorOn = _colorScheme.GetGameColor(_backgroundSchemeColorOn);
            _backgroundColorOff = _colorScheme.GetGameColor(_backgroundSchemeColorOff);
        }

        private void ResolveColorVisuals()
        {
            //if (!Interactable)
            //{
            //    _text.color = _textColor.Greyed;
            //    _image.color = _backgroundColorOn.Greyed;
            //}
            //else
            //{
            //    if (ToggleState) ResolveNeutralHoverColorVisuals(_textColor, _backgroundColorOn);
            //    else ResolveNeutralHoverColorVisuals(_textColor, _backgroundColorOff);
            //}
        }

        private void ResolveNeutralHoverColorVisuals(GameColor textColor, GameColor imageColor)
        {
            _text.color = _isHovering ? textColor.Dark : textColor.Base;
            _image.color = _isHovering ? imageColor.Dark : imageColor.Base;
        }

        protected override void HandleContentRender()
        {
            throw new System.NotImplementedException();
        }
    }
}
