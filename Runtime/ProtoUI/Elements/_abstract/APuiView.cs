using HexUN.MonoB;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Abstract class for all views
    /// </summary>
    public abstract class APuiView<T> : MonoEnhanced
        where T: MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Control used by the view")]
        protected T Control = default;

        /// <summary>
        /// set to true in order to cause handle render to be called this frame
        /// </summary>
        protected bool RenderThisFrame { get; set; }

        private void LateUpdate() {
            if (RenderThisFrame)
            {
                HandleFrameRender();
                RenderThisFrame = false;
            }
        }

        #region API
        /// <summary>
        /// Initalization code for the ui element
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Call to force a render to happen this frame. A render will do work to
        /// update a views visuals. 
        /// </summary>
        public void Render()
        {
            RenderThisFrame = true;
        }
        #endregion

        protected virtual void OnValidate()
        {
            if (Control == null) Control = gameObject.GetComponent<T>();
        }

        /// <summary>
        /// Handle the logic required when a render occurs
        /// </summary>
        protected abstract void HandleFrameRender();
    }
}