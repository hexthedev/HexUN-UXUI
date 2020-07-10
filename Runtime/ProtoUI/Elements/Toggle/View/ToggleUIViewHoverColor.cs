using System;
using System.Collections.Generic;
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
    public class ToggleUIViewHoverColor : AToggleUIView
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

        [Header("Debugging (ToggleUIViewHoverColor)")]
        [SerializeField]
        private GameColor _textColor = default;

        [SerializeField]
        private GameColor _backgroundColorOn = default;

        [SerializeField]
        private GameColor _backgroundColorOff = default;

        [Header("View State")]
        [SerializeField]
        private bool _state = default;

        [SerializeField]
        private bool _isHovering = default;

        [SerializeField]
        private bool _interactable = default;

        private bool changedThisFrame = false;

        #region Protected API
        protected override void MonoAwake()
        {
            base.MonoAwake();
            _state = ToggleUIState.ToggleState;
            ResolveColorReferences();
        }

        protected override void MonoStart()
        {
            base.MonoStart();
            CallAfterStart(o => SetToggleState(_state));
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            ResolveColorReferences();
            SetToggleState(_state);
            ResolveColorVisuals();
        }
        #endregion

        #region Public API
        public void HandleHoverableEvent(EHoverableEvent hover)
        {
#if TOBIAS_DEBUG
            if (Log != null) Log.Invoke($"${gameObject.name}:{nameof(ToggleUIViewHoverColor)} received hover event {hover}");
#endif
            if(hover != EHoverableEvent.Down) // toggle doesn't react to down
            {
                _isHovering = hover == EHoverableEvent.Hovering;

                if (!IsStarted) ResolveColorVisuals();
                else changedThisFrame = true;
            }
        }

        public override void Initialize(bool isInteractable, bool toggleState)
        {
            _interactable = isInteractable;
            _state = toggleState;
            ResolveColorVisuals();
        }

        public override void HandleInteractionState(bool interactionState)
        {
            _interactable = interactionState;

            if (!IsStarted) ResolveColorVisuals();
            else changedThisFrame = true;
        }

        public override void HandleToggleState(bool state)
        {
            SetToggleState(state);
        }
        #endregion

        private void SetToggleState(bool state)
        {
            _state = state;

            if (!IsStarted) ResolveColorVisuals();
            else changedThisFrame = true;

        }

        private void Update()
        {
            if (changedThisFrame) ResolveColorVisuals();
        }

        private void ResolveColorReferences()
        {
            _textColor = _colorScheme.GetGameColor(_textSchemeColor);
            _backgroundColorOn = _colorScheme.GetGameColor(_backgroundSchemeColorOn);
            _backgroundColorOff = _colorScheme.GetGameColor(_backgroundSchemeColorOff);
        }

        private void ResolveColorVisuals()
        {
            if (!_interactable)
            {
                _text.color = _textColor.Greyed;
                _image.color = _backgroundColorOn.Greyed;
            }
            else
            {
                if (_state) ResolveNeutralHoverColorVisuals(_textColor, _backgroundColorOn);
                else ResolveNeutralHoverColorVisuals(_textColor, _backgroundColorOff);
            }
        }

        private void ResolveNeutralHoverColorVisuals(GameColor textColor, GameColor imageColor)
        {
            _text.color = _isHovering ? textColor.Dark : textColor.Base;
            _image.color = _isHovering ? imageColor.Dark : imageColor.Base;
        }
    }
}