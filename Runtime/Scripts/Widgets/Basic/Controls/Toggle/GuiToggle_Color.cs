using TMPro;
using HexUN.Design;
using HexUN.Input;
using UnityEngine;
using UnityEngine.UI;
using HexUN.Utilities;

namespace HexUN.UXUI
{
    /// <summary>
    /// Toggles the color of a text and an image using Hoverable interaction events
    /// </summary>
    public class GuiToggle_Color : AGuiToggleBehaviour
    {
        [Header("[GuiToggle_Color]")]
        [Header("Dependencies")]
        [SerializeField]
        private Image _image = default;

        [Header("Options")]
        [SerializeField] private Color OnNeutral;
        [SerializeField] private Color OnHover;
        [SerializeField] private Color OnDown;
        [SerializeField] private Color OnDisabled;
        [SerializeField] private Color OffNeutral;
        [SerializeField] private Color OffHover;
        [SerializeField] private Color OffDown;
        [SerializeField] private Color OffDisabled;

        private OnChangeVariable<bool> _interactable;
        private OnChangeVariable<EHoverableEvent> _hoverState;

        #region Public API
        /// <summary>
        /// The interactability status currently applied to the toggle
        /// </summary>
        public bool Interactable
        {
            get => GetOccasional(ref _interactable);
            set => SetOccasional(ref _interactable, value);
        }

        /// <summary>
        /// The hoverable event currently being applied to the toggle
        /// </summary>
        public EHoverableEvent HoverableEvent
        {
            get => GetOccasional(ref _hoverState);
            set => SetOccasional(ref _hoverState, value);
        }
        #endregion

        protected override void HandleOccasionalRender()
        {
            if (ToggleState) ResolveColor(OnNeutral, OnHover, OnDown, OnDisabled);
            else ResolveColor(OffNeutral, OffHover, OffDown, OffDisabled);
        }

        protected override void HandleFrequentRender() { }

        private void ResolveColor(Color neutral, Color hover, Color down, Color disabled)
        {
            if (!Interactable)
            {
                _image.color = disabled;
                return;
            }

            switch(HoverableEvent)
            {
                case EHoverableEvent.Absent:
                    _image.color = neutral;
                    break;
                case EHoverableEvent.Down:
                    _image.color = down;
                    break;
                case EHoverableEvent.Hovering:
                    _image.color = hover;
                    break;
            }
        }
    }
}
