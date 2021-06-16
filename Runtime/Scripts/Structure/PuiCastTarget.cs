using HexUN.Sub.UIUX.Framework;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Should put put on the same level as the unity graphic that is being cast to. 
    /// acts as a bridge to a PuiControl
    /// </summary>
    public class PuiCastTarget : MonoBehaviour
    {
        [SerializeField]
        private GuiRenderBehaviour _control = null;

        #region API
        public GuiRenderBehaviour Control => _control;
        #endregion
    }
}