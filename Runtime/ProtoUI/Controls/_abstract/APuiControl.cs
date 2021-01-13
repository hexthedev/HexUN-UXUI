using System.Collections.Generic;
using UnityEngine;
using HexUN.Render;
using HexUN.Facade;

namespace HexUN.UXUI
{
    /// <summary>
    /// Abstract class for all controls
    /// </summary>
    public abstract class APuiControl : AVisualFacade
    {
        #region API
        /// <summary>
        /// The Rect transform of the element
        /// </summary>
        public RectTransform RectTransform => transform as RectTransform;
        #endregion
    }
}