using HexUN.Input;

namespace HexUN.UXUI
{
    public abstract class AHoverActivatable : APuiControl
    {
        private EHoverableEvent _hoverEvent = EHoverableEvent.Absent; 

        public EHoverableEvent HoverEvent
        {
            get => _hoverEvent;
            set
            {
                if (value == _hoverEvent) return;
                _hoverEvent = value;
                Render();
            }
        }
    }
}