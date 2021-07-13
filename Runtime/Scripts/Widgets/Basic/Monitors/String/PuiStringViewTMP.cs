using TMPro;

using UnityEngine;

namespace HexUN.UXUI
{
    public class PuiStringViewTMP : APuiStringView
    {
        [Header("Options (Render)")]
        [SerializeField]
        [Tooltip("The text reference to update with provided string")]
        private TMP_Text _text;

        protected override void HandleFrequentRender()
        {
            throw new System.NotImplementedException();
        }

        protected override void HandleOccasionalRender()
        {
            _text.text = StringValue;
        }
    }
}