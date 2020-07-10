using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// The state of the swipe at the frame swipe data was collected
    /// </summary>
    public enum ESwipeState
    {
        /// <summary>
        /// This means that the swipe is still mid swipe. Intended behaviour is that
        /// mid swipe objects do not pop out, but may poke into the scene to show
        /// that the swipe is working
        /// </summary>
        SWIPING = 0,

        /// <summary>
        /// This means that the swipe ends, but the magnitude was not met so that a true swipe
        /// occured. The swipe input should not be used as a user intended interaction. Rather, 
        /// anything that was startign to poke should return
        /// </summary>
        FAILED = 1,

        /// <summary>
        /// This means that the swipe ended and the magnitude was met. The swipe can be used as
        /// an interaction
        /// </summary>
        SUCCEEDED = 2
    }
}