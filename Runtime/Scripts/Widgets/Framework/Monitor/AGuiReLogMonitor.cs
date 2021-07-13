using HexCS.Core;

using HexUN.Framework.Debugging;
using HexUN.Sub.UIUX.Framework;

using UnityEngine;

namespace HexUN.Sub.UIUX.Widgets
{
    public abstract class AGuiReLogMonitor : AGuiRenderBehaviour
    {
        private EventBinding _logBinding;

        [Header("[AGuiReLogMonitor]")]
        [SerializeField]
        private ReLogs _logs;

        protected override void OnEnable()
        {
            base.OnEnable();

            if(_logs != null)
            {
                _logBinding = _logs.OnUpdated.Subscribe(HandleOccasionalRender);
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            if (_logBinding != null) _logBinding.UnSubscribe();
            _logBinding = null;
        }

        /// <inheritdoc />
        protected override void HandleOccasionalRender() => HandleLogRender(_logs);

        /// <summary>
        /// When logs are updated, perform a new render
        /// </summary>
        protected abstract void HandleLogRender(ReLogs log);
    }
}