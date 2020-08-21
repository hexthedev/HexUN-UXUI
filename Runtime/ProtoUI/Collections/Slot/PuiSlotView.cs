using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    public class PuiSlotView : APuiSlotCollectionControl
    {
        [Header("Dependencies (APuiSlotView)")]
        [SerializeField]
        [Tooltip("Sprite configuration for empty disabled slot")]
        public SpriteArgs EmptyDisabledSprite = null;

        [SerializeField]
        [Tooltip("Sprite configuration for empty enabled slot")]
        public SpriteArgs EmptyEnabledSprite = null;

        [SerializeField]
        [Tooltip("Image component used to show the slot visuals")]
        protected Image ImageComponent = null;

        [Header("Dependencies (SlotView)")]
        [SerializeField]
        private Transform _occupationParent = null;

        /// <inheritidoc />
        protected void OnValidate()
        {
            HandleFrameRender();
        }

        /// <inheritidoc />
        protected override void HandleFrameRender()
        {
            GameObject occu = OccupyingObject;
            if (occu == null) return;

            occu.transform.SetParent(_occupationParent, false);
        }
    }
}
