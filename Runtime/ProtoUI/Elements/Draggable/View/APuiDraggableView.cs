using HexCS.Core;

namespace HexUN.UXUI
{
    public abstract class APuiDraggableView : APuiView<PuiDraggableControl>
    {
        /// <summary>
        /// Invoked when the draggable view is dropped with the Vector2
        /// position within some frame of reference
        /// </summary>
        protected Event<UnityEngine.Vector2> OnDroppedEvent = new Event<UnityEngine.Vector2>();
    }
}