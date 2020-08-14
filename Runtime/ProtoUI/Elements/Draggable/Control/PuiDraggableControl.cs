using HexCS.Core;
using HexUN.Events;
using HexUN.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;

namespace HexUN.UXUI
{
    public class PuiDraggableControl : APuiControl<APuiDraggableView>
    {
        [Header("Emissions")]
        [SerializeField]
        [Tooltip("Invoked when dropped")]
        private PointerEventDataReliableEvent _onDroppedEvent;

        #region API
        /// <summary>
        /// Invoked when then draggable is dropped, with the drop location 
        /// </summary>
        public IEventSubscriber<PointerEventData> OnDroppedEvent => _onDroppedEvent;

        public void Start()
        {
            if (_onDroppedEvent != null) EventBindings.Add(View.OnDropped.Subscribe(_onDroppedEvent.Invoke));
        }
        #endregion
    }
}