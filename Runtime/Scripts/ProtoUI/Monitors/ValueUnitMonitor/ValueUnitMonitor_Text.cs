using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace HexUN.Sub.UIUX.ProtoUi
{
    /// <summary>
    /// Monitors a value and a unit provided as text. The unit is considered a style element
    /// and assumed to change rarely
    /// </summary>
    public class ValueUnitMonitor_Text : AValueUnitMonitor<string, string>
    {
        [Header("[ValueUnitMonitor]")]
        [SerializeField]
        [Tooltip("Reference to the Text that will render the value")]
        private TMP_Text _valueText;

        [SerializeField]
        [Tooltip("Reference to the Text that will render the Unit")]
        private TMP_Text _unitText;

        protected override void HandleUnitChange(string value)
        {
            _unitText.text = value;
        }

        protected override void HandleValueChange(string value)
        {
            _valueText.text = value;
        }
    }
}