using UnityEngine;
using HexCS.Core;
using HexUN.Events;
using HexUN.Sub.UIUX.Framework;

namespace HexUN.Sub.UIUX
{
    public abstract class GuiButtonBehaviour : GuiRenderBehaviour
    {
        [Header("[GuiButtonBehaviour]")]
        [Header("Actions")]
        [SerializeField]
        protected VoidReliableEvent _onClick = new VoidReliableEvent();

        public void Click()
        {
            _onClick.Invoke();
        }
    }
}