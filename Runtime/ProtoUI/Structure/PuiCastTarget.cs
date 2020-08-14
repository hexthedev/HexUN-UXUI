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
        private APuiControl _control = null;

        #region API
        public APuiControl Control => _control;
        #endregion
    }
}