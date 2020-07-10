namespace HexUN.UXUI
{
    /// <summary>
    /// Provides the state of a toggle
    /// </summary>
    public interface IToggleUIState
    {
        /// <summary>
        /// The current state of the toggle
        /// </summary>
        bool ToggleState { get; }
    }
}