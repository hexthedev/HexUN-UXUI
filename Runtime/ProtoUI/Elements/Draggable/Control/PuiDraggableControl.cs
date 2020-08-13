using HexUN.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI
{
    public class PuiDraggableControl : APuiControl<APuiDraggableView>
    {
        [Header("Emissions")]
        [SerializeField]
        [Tooltip("Invoked when dropped")]
        private Vector2ReliableEvent _onDroppedEvent;

        public void Start()
        {
            if (_onDroppedEvent != null) EventBindings.Add(View.OnDropped.Subscribe(_onDroppedEvent.Invoke));
        }
    }
}