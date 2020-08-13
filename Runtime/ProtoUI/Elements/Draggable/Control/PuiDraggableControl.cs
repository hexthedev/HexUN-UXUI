using HexUN.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI
{
    public class PuiDraggableControl : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private APuiDraggableView _view;

        [Header("Emissions")]
        [SerializeField]
        [Tooltip("Invoked when dropped")]
        private Vector2ReliableEvent _onDroppedEvent;


    }
}