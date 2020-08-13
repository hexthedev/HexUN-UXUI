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
        public override GameObject OccupyingObject => throw new System.NotImplementedException();

        public void Clear()
        {
            View.Clear();
        }

        public void PopulateSlot(GameObject populate)
        {
            View.PopulateSlot(populate);
        }

        protected override void ClearOccupying() => throw new System.NotImplementedException();
    }
}