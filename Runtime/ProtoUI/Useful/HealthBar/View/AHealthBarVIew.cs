using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI
{
    public abstract class AHealthBarView : MonoBehaviour
    {
        /// <summary>
        /// Set the bar to a value between 0 and 1
        /// </summary>
        /// <param name="val"></param>
        public abstract void SetBarValue(float val);
    }
}