using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    public class HealthBarView : AHealthBarView
    {
        [Header("Dependencies (HealthBarView)")]
        [SerializeField]
        private Image _bar = null;

        [SerializeField]
        private Image _background = null;

        [Header("Debug")]
        [Range(0, 1)]
        [SerializeField]
        private float _value = 0;


        /// <inheritdoc />
        public override void SetBarColor(Color main, Color background)
        {
            _bar.color = main;
            _background.color = background;
        }

        /// <inheritdoc />
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