namespace HexUN.UXUI
{
    /// <summary>
    /// Provides an API to Toggle clients that allows to control and list to the toggle 
    /// </summary>
    public interface IToggleUIControl : IToggleUIState
    {
        /// <summary>
        /// Get or set the state of the toggle
        /// </summary>
        void Toggle();

        /// <summary>
        /// Force the toggle to a particular state
        /// </summary>
        /// <param name="state"></param>
        void ForceToggle(bool state);
    }
}