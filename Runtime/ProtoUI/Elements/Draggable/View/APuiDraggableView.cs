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

        /// <summary>
        /// Event invoked when the draggable is droped. Provides the dropped screen position
        /// </summary>
        public IEventSubscriber<UnityEngine.Vector2> OnDropped => OnDroppedEvent;
    }
}