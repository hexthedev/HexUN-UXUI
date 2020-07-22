using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    /// <summary>
    /// Control a PTHealthBar element
    /// </summary>
    public class HealthBarControl : MonoBehaviour
    {
        [Header("Deps")]
        [SerializeField]
        private AHealthBarView _view;

        [Header("State")]
        [Range(0, 1)]
        [SerializeField]
        private float _value;

        #region API
        /// <summary>
        /// Value of the bar
        /// </summary>
        public float Value => _value;

        /// <summary>
        /// Set the bar to a value between 0 and 1
        /// </summary>
        /// <param name="val"></param>
        public void SetBarValue(float val)
        {
            if(_view != null) _view.SetBarValue(val);
        }
        #endregion

        private void OnValidate()
        {
            SetBarValue(_value);
        }
    }
}