using HexUN.MonoB;
using UnityEngine;

namespace HexUN.UXUI
{
    public abstract class AHealthBarView : MonoEnhanced
    {
        /// <summary>
        /// Set the color of the bar
        /// </summary>
        /// <param name="col"></param>
        public abstract void SetBarColor(Color main, Color background);

        /// <summary>
        /// Set the bar to a value between 0 and 1
        /// </summary>
        /// <param name="val"></param>
        public abstract void SetBarValue(float val);
    }
}