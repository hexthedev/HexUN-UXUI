using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// A slot is a ui element that has a representative sprite for empty, and can be
    /// filled with some custom sprite on command. Supports ability to drag slot objects
    /// and provides a drop location via event. 
    /// </summary>
    public class PuiSlotControl : APuiSlotControl
    {
        private GameObject _occupyingObject;

        public override GameObject OccupyingObject => _occupyingObject;

        public override void Clear()
        {
            Destroy(OccupyingObject);
            Clear();
        }

        public override void PopulateSlot(GameObject populate)
        {
            _occupyingObject = populate;
            RenderView();
        }

        protected override void ClearOccupying()
        {
            _occupyingObject = null;
            RenderView();
        }
    }
}