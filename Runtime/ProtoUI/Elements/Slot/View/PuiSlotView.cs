using UnityEngine;

namespace HexUN.UXUI
{
    public class PuiSlotView : APuiSlotView
    {
        [Header("Dependencies (SlotView)")]
        private Transform _occupationParent;

        [Header("Dependencies (Options)")]
        public bool IsEnabled = false;
               
        private OccupationInstruction _occupationInstruction;
        private GameObject _occupyingObject;

        #region API
        public override void PopulateSlot(GameObject obj)
        {
            _occupyingObject = obj;
            _occupationInstruction = OccupationInstruction.AddOccupied;
            Render();
        }

        public override void Clear()
        {
            EmptyEnabledSprite.ApplyToImage(ImageComponent);
        }
        #endregion

        protected override void OnValidate()
        {
            HandleFrameRender();
        }

        protected override void HandleFrameRender()
        {
            if (IsEnabled) EmptyEnabledSprite.ApplyToImage(ImageComponent);
            else EmptyDisabledSprite.ApplyToImage(ImageComponent);

            switch (_occupationInstruction)
            {
                case OccupationInstruction.AddOccupied:
                    _occupyingObject.transform.SetParent(_occupationParent, false);
                    _occupationInstruction = OccupationInstruction.None;
                    break;
                case OccupationInstruction.RemoveOccupied:
                    Destroy(_occupyingObject);
                    _occupationInstruction = OccupationInstruction.None;
                    break;
            }
        }

        private enum OccupationInstruction
        {
            None = 0,
            AddOccupied = 1,
            RemoveOccupied = 2
        }
    }
}
