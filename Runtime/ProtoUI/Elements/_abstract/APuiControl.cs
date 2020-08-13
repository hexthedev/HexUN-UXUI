using HexUN.MonoB;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Abstract class for all views
    /// </summary>
    public abstract class APuiControl<T> : APuiControl
        where T: APuiView
    {
        [Header("View")]
        [SerializeField]
        [Tooltip("Control used by the view")]
        protected T View = default;

        #region API
        /// <summary>
        /// Initalization code for the ui element
        /// </summary>
        public override void Initialize()
        {
            View.Initialize();
        }
        #endregion

        protected virtual void OnValidate()
        {
            if (View == null) View = gameObject.GetComponent<T>();
        }
    }

    /// <summary>
    /// Abstract class for all views
    /// </summary>
    public abstract class APuiControl : MonoEnhanced
    {
        #region API
        /// <summary>
        /// Initalization code for the ui element
        /// </summary>
        public virtual void Initialize() { }
        #endregion
    }
}