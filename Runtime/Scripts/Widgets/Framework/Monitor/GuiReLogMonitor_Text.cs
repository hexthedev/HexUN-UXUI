using HexUN.Framework;
using HexUN.Framework.Debugging;

using System.Text;

using TMPro;

using UnityEngine;

namespace HexUN.Sub.UIUX.Widgets
{
    public class GuiReLogMonitor_Text : AGuiReLogMonitor
    {
        private const string cLogCategory = nameof(GuiReLogMonitor_Text);

        private StringBuilder _sb = new StringBuilder();

        [Header("[GuiReLogMonitor_Text]")]
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private bool _isUser;

        [SerializeField]
        private bool _isVerbose;

        protected override void HandleFrequentRender() { }

        protected override void HandleLogRender(ReLogs log)
        {
            _sb.Clear();

            if(log == null)
            {
                Debug.LogWarning($"Failed to render log because {nameof(ReLogs)} is null");
            }

            foreach(SrLog srlog in log.Logs)
            {
                if(!_isUser || srlog.IsUserLog)
                {
                    _sb.AppendLine(_isVerbose ?
                        $"> [{srlog.Severity}] [{srlog.Category}] {srlog.Message}" :
                        $"> {srlog.Message}"
                    );
                }
            }

            _text.text = _sb.ToString();
        }
    }
}