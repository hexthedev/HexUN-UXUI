using HexUN.Input;

namespace HexUN.UXUI
{
    public enum EUiVisualState
    {
        Neutral,
        Hover,
        Down,
        Highlighted,
        Disabled
    }

    public static class UTEUiVisualState
    {
        /// <summary>
        /// Converts to standard visual state from hoverable event
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        public static bool TryFromEHoverableEvent(EHoverableEvent evt, out EUiVisualState state)
        {
            switch (evt)
            {
                case EHoverableEvent.Absent:
                    state = EUiVisualState.Neutral;
                    return true;
                case EHoverableEvent.Down:
                    state = EUiVisualState.Down;
                    return true;
                case EHoverableEvent.Hovering:
                    state = EUiVisualState.Hover;
                    return true;
            }

            state = default;
            return false;
        }
    }
}