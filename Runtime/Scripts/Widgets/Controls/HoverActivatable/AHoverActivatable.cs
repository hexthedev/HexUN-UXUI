using HexUN.Input;
using HexUN.Sub.UIUX.Framework;

namespace HexUN.Sub.UIUX
{
    public abstract class AHoverActivatable : AGuiRenderBehaviour
    {
        private EHoverableEvent _hoverEvent = EHoverableEvent.Absent; 

        public EHoverableEvent HoverEvent
        {
            get => _hoverEvent;
            set
            {
                if (value == _hoverEvent) return;
                _hoverEvent = value;
                RenderAll();
            }
        }
    }
}