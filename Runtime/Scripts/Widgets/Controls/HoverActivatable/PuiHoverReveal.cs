using HexUN.Input;
using HexUN.Sub.UIUX.Framework;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI {
    public class PuiHoverReveal : AGuiRenderBehaviour
    {
        [Header("Options")]
        [SerializeField]
        [Tooltip("Activates and deactivates monobehavious based on hover event")]
        private MonoBehaviour[] _hideOnHover;

        protected override void HandleFrequentRender()
        {
            throw new System.NotImplementedException();
        }

        protected override void HandleOccasionalRender()
        {
            //switch (HoverEvent)
            //{
            //    case EHoverableEvent.Absent:
            //        foreach (MonoBehaviour mb in _hideOnHover) mb.enabled = false;
            //        return;
            //}

            foreach (MonoBehaviour mb in _hideOnHover) mb.enabled = true;
        }
    }
}