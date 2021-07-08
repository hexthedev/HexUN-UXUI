using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace HexUN.Sub.UIUX.Widgets
{
    /// <summary>
    /// Changes the width or height of the forground image
    /// </summary>
    public class FloatMonitor_ProgressBar : AValueMonitor<float>
    {
        [SerializeField]
        [Tooltip("Text representation of the float shown")]
        private TMP_Text _text;

        [SerializeField]
        [Tooltip("The image that will not change")]
        private Image _background;

        [SerializeField]
        [Tooltip("The image that will be grown")]
        private Image _foreground;

        [SerializeField]
        [Tooltip("Should the progress effect the x or y axis")]
        private bool _useX;

        [SerializeField]
        [Tooltip("If true, changes the height/width max, otherwise changes the min")]
        private bool _targetMax;

        protected override void HandleOccasionalRender() { }

        protected override void HandleValueRender(float value)
        {
            _text.text = value.ToString("0.00");

            if (_targetMax)
            {
                Vector2 currentMax = _foreground.rectTransform.anchorMax;
                if (_useX) _foreground.rectTransform.anchorMax = new Vector2(value, currentMax.y);
                else _foreground.rectTransform.anchorMax = new Vector2(currentMax.x, value);
            }
            else
            {
                Vector2 currentMin = _foreground.rectTransform.anchorMin;
                if (_useX) _foreground.rectTransform.anchorMin = new Vector2(1-value, currentMin.y);
                else _foreground.rectTransform.anchorMin = new Vector2(currentMin.x, 1-value);
            }
        }
    }
}