using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    public class HealthBarView : AHealthBarView
    {
        [Header("Deps")]
        [SerializeField]
        private Image _bar;

        [Header("Debug")]
        [Range(0, 1)]
        [SerializeField]
        private float _value;

        /// <summary>
        /// Set the bar to a value between 0 and 1
        /// </summary>
        /// <param name="val"></param>
        public override void SetBarValue(float val)
        {
            if (_bar != null)
            {
                _value = Mathf.Clamp(val, 0, 1);
                _bar.rectTransform.anchorMax = new Vector2(_value, 1);
            }
        }

        private void OnValidate()
        {
            SetBarValue(_value);
        }
    }
}