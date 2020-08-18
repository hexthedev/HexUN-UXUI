using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Slots are pieces of a Ui that can contain elements, or be empty. For example, you
    /// might drag items into inventory slots. 
    /// </summary>
    public abstract class APuiSlotControl : APuiControl<APuiSlotView>
    {
        #region API       
        /// <summary>
        /// The game object currently occupying the slot
        /// </summary>
        public abstract GameObject OccupyingObject { get; }

        /// <summary>
        /// The current state of the slot
        /// </summary>
        public State CurrentState { get; protected set; } = State.EmptyDisabled;

        public abstract void Clear();

        public abstract void PopulateSlot(GameObject populate);

        /// <summary>
        /// Empty the slot, deleting the object. Set the empty slot to enabled or disabled
        /// </summary>
        /// <param name="state"></param>
        public void SetEmptyAndState(bool enabled)
        {
            State state = enabled ? State.EmptyEnabled : State.EmptyDisabled;
            RenderView();
        }
        #endregion

        /// <summary>
        /// Used when emptying the slot. Clears the occupying slot
        /// </summary>
        protected abstract void ClearOccupying();

        #region Internal Objects
        public enum State
        {
            EmptyDisabled = 0,
            EmptyEnabled = 1,
            Occupied
        }
        #endregion
    }
}