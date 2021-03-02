using HexUN.MonoB;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// A slot is a ui element that has a representative sprite for empty, and can be
    /// filled with some custom sprite on command. Supports ability to drag slot objects
    /// and provides a drop location via event. 
    /// </summary>
    public abstract class APuiSlotCollection : HexBehaviour
    {
        #region API       
        /// <summary>
        /// The game object currently occupying the slot
        /// </summary>
        public GameObject OccupyingObject { get; private set; }

        /// <summary>
        /// Destroy any occupying object in the slot
        /// </summary>
        public void Clear()
        {
            Destroy(OccupyingObject);
            OccupyingObject = null;
        }

        /// <summary>
        /// Populuate the slot with some object
        /// </summary>
        /// <param name="obj"></param>
        public void SetOccupying(GameObject populate)
        {
            OccupyingObject = populate;
        }

        /// <summary>
        /// The current state of the slot
        /// </summary>
        public State CurrentState { get; protected set; } = State.EmptyDisabled;

        /// <summary>
        /// Empty the slot, deleting the object. Set the empty slot to enabled or disabled
        /// </summary>
        /// <param name="state"></param>
        public void SetEmptyAndState(bool enabled)
        {
            State state = enabled ? State.EmptyEnabled : State.EmptyDisabled;
        }
        #endregion

        #region Internal Objects
        /// <summary>
        /// State of a SlotControl
        /// </summary>
        public enum State
        {
            EmptyDisabled = 0,
            EmptyEnabled = 1,
            Occupied
        }
        #endregion

    }
}