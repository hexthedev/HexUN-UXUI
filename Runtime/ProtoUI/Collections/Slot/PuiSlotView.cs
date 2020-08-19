using UnityEngine;

namespace HexUN.UXUI
{
    public class PuiSlotView : APuiSlotView
    {
        [Header("Dependencies (SlotView)")]
        [SerializeField]
        private Transform _occupationParent = null;

        /// <inheritidoc />
        protected override void OnValidate()
        {
            HandleFrameRender();
        }

        /// <inheritidoc />
        protected override void HandleFrameRender()
        {
            GameObject occu = Control.OccupyingObject;
            if (occu == null) return;

            occu.transform.SetParent(_occupationParent, false);
        }
    }
}
