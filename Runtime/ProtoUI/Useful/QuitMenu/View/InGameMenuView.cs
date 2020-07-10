using System.Collections;
using System.Collections.Generic;
using HexUN.Patterns;
using HexUN.UXUI;
using UnityEngine;

namespace HexUN.UXUI
{
    public class InGameMenuView : AInGameMenuView
    {
        [Header("Options (InGameMenuView)")]
        [SerializeField]
        [Tooltip("Gameobjects that make up the mainmenu")]
        GameObject[] _menuObjects;

        [Header("State (InGameMenuView)")]
        [SerializeField]
        private bool _isActive = false;

        public override void HandleActivate(CVCommand command) => SetObjectActivation(true);
        public override void HandleDeactivate(CVCommand command) => SetObjectActivation(false);
        public override void HandleQuit(CVCommand command) { }
        public override void HandleResume(CVCommand command) { }

        private void SetObjectActivation(bool isActive)
        {
            if (_isActive == isActive) return;
            ForceObjectActivation(isActive);
        }

        private void ForceObjectActivation(bool isActive)
        {
            foreach (GameObject obj in _menuObjects)
            {
                obj.SetActive(isActive);
            }

            _isActive = isActive;
        }
        
        protected override void MonoStart()
        {
            base.MonoStart();
            ForceObjectActivation(InGameMenuProvider.IsActive);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            ForceObjectActivation(InGameMenuProvider.IsActive);
        }
    }
}