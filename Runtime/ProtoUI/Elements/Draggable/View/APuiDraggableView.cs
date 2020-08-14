using HexCS.Core;
using UnityEngine.EventSystems;

namespace HexUN.UXUI
{
    public abstract class APuiDraggableView : APuiView<PuiDraggableControl>
    {
        /// <summary>
        /// Invoked when the draggable view is dropped with the Vector2
        /// position within some frame of reference
        /// </summary>
        protected Event<PointerEventData> OnDroppedEvent = new Event<PointerEventData>();

        /// <summary>
        /// Event invoked when the draggable is droped. Provides the dropped screen position
        /// </summary>
        public IEventSubscriber<PointerEventData> OnDropped => OnDroppedEvent;
    }
}