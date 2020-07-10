using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace HexUN.UXUI
{
    [SelectionBase]
    public class InGameMenuControl : AInGameMenuControl
    {
        private const int cActivateWork = 0;
        private const int cDeactivateWork = 0;
        private const int cResumeWork = 1;
        private const int cQuitWork = 2;

        [Header("State (InGameMenuControl)")]
        [SerializeField]
        private bool _isActive = false;

        public override bool IsActive => _isActive;

        public override void Activate()
        {
            SendCommandIfIdle(ref _onActivate, cActivateWork);
            _isActive = true;
        }

        public override void Deactivate()
        {
            SendCommandIfIdle(ref _onDeactivate, cDeactivateWork);
            _isActive = false;
        }

        public override void Quit() => SendCommandIfIdle(ref _onQuit, cQuitWork);

        public override void Resume() => SendCommandIfIdle(ref _onResume, cResumeWork);

        public void Toggle(bool isActive)
        {
            if (isActive) Activate();
            else Deactivate();
        }

        protected override void MonoStart()
        {
            base.MonoStart();
            if (_isActive) Activate();
            else Deactivate();
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            if (_isActive) Activate();
            else Deactivate();
        }
    }
}