using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace HexUN.Sub.UIUX
{
    /// <summary>
    /// Gets the size of rendered values and changes rect transform size accordingly
    /// </summary>
    public class TMPBottomBoundShifter : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;

        private RectTransform _rect;
        private float _originalAnchoredY;

        private Vector2 _lastRenderedSize = Vector2.zero;

        public void Awake()
        {
            _rect = _text.gameObject.transform as RectTransform;
            _originalAnchoredY = _rect.anchoredPosition.y;
        }

        public void Update()
        {
            Vector2 renderedSize = _text.GetRenderedValues(true);

            if (renderedSize == _lastRenderedSize) return;
            _lastRenderedSize = renderedSize;

            if(renderedSize.y > _rect.rect.height)
            {
                float diff = renderedSize.y - _rect.rect.height;
                _rect.anchoredPosition = new Vector2(_rect.anchoredPosition.x, _originalAnchoredY + diff);
            }
            else
            {
                _rect.anchoredPosition = new Vector2(_rect.anchoredPosition.x, _originalAnchoredY);
            }
        }
    }
}