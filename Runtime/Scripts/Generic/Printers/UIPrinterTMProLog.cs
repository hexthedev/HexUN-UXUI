using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Prints a number of strings to a textMeshPro element. 
    /// Very simple, more for prototpying. 
    /// </summary>
    public class UIPrinterTMProLog : AUIPrinter<string>
    {
        private StringBuilder _sb = new StringBuilder();
        private List<string> _logs = new List<string>();

        [SerializeField]
        [Tooltip("Place to log console log")]
        private TextMeshProUGUI _text = null;

        [SerializeField]
        [Tooltip("Max Lines")]
        private int _max = default;

        public override void Print(string value)
        {
            _logs.Add(value);
            SetLogText();
        }

        private void SetLogText()
        {
            _sb.Clear();

            if (_logs.Count < _max)
            {
                foreach (string s in _logs)
                {
                    _sb.AppendLine(s);
                }
            }
            else
            {
                for (int i = _logs.Count - _max; i < _logs.Count; i++)
                {
                    _sb.AppendLine(_logs[i]);
                }
            }

            _text.text = _sb.ToString();
        }
    }
}