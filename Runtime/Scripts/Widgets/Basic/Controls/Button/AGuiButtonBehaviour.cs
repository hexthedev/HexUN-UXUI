using HexUN.Events;
using HexUN.Sub.UIUX.Framework;

using UnityEngine;

namespace HexUN.Sub.UIUX
{
    public abstract class AGuiButtonBehaviour : AGuiRenderBehaviour
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