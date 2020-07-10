using HexUN.Deps;
using HexUN.MonoB;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HexUN.UXUI
{
    /// <summary>
    /// Uses Hoverable event consumption flow to control the
    /// view of a toggle type object
    /// </summary>
    public abstract class AToggleUIView : MonoDependent
    {
        [Header("Dependencies (AToggleViewHover)")]
        [SerializeField]
        private Object _toggleUIState = null;

        protected IToggleUIState ToggleUIState;

        protected override void ResolveDependencies()
        {
            UTDependency.Resolve(ref _toggleUIState, out ToggleUIState, this);
        }

        /// <summary>
        /// Forces the state based on
        /// </summary>
        /// <param name="isInteractable"></param>
        /// <param name="toggleState"></param>
        public abstract void Initialize(bool isInteractable, bool toggleState);

        /// <summary>
        /// Handle visual changes that occur when the state of the toggle changes
        /// </summary>
        /// <param name="state"></param>
        public abstract void HandleToggleState(bool state);

        /// <summary>
        /// Handle visual changes that occur when the state of the interactablility changes
        /// </summary>
        /// <param name="interactionState"></param>
        public abstract void HandleInteractionState(bool interactionState);
    }
}
