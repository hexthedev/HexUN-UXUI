using TMPro;

using UnityEngine;

namespace HexUN.Sub.UIUX.ProtoUi
{
    public class StringMonitor_TMPText : AValueMonitor<string>
    {
        [Header("[StringMonitor]")]
        [SerializeField]
        [Tooltip("Reference to text that will be updated by the string monitor")]
        private TMP_Text _text;

        protected override void HandleValueRender(string value)
        {
            _text.text = value;
        }

        protected override void HandleOccasionalRender() { }
    }
}