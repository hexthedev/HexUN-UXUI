using HexCS.Core;
using HexUN.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HexUN.UXUI
{
    public abstract class APuiDraggableControl : APuiControl
    {
        [Header("Emissions")]
        [SerializeField]
        [Tooltip("Invoked when dropped")]
        protected PointerEventDataReliableEvent _onDroppedEvent = null;

        #region API
        /// <summary>
        /// Invoked when then draggable is dropped, with the drop location 
        /// </summary>
        public IEventSubscriber<PointerEventData> OnDroppedEvent => _onDroppedEvent;
        #endregion
    }
}