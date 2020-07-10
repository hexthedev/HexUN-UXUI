using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexUN.UXUI
{
    public struct SSwipeData
    {
        /// <summary>
        /// The current direction of the swipe
        /// </summary>
        public ESwipeDirection Direction;

        /// <summary>
        /// State of the swipe this frame
        /// </summary>
        public ESwipeState State;

        /// <summary>
        /// The magnitude of movement currently occuring from
        /// the origin of the swipe to the current position of the
        /// swipe along the SwipeDirection axis vector. 
        /// </summary>
        public float DirectionalMagnitude;
    }
}
