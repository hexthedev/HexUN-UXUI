using HexUN.Sub.UIUX;

using System;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// The view for a selection group.
    /// </summary>
    public class PuiSelectionBar : APuiSelectionBar
    {
        [Header("Options")]
        [SerializeField]
        [Tooltip("The buttons in the group")]
        private AGuiButtonBehaviour[] _groupButtons = null;

        private void Start()
        {
            for(int i = 0; i<_groupButtons.Length; i++)
            {
                //_groupButtons[i].OnClick.Subscribe(ClickResponseFactory(i));
            }

            //Action ClickResponseFactory(int index) => () =>  RequestSelectionChange(index);
        }

        protected override void HandleOccasionalRender()
        {
            //for (int i = 0; i < _groupButtons.Length; i++)
            //{
            //    // disable
            //    if (i > MaxActiveIndex)
            //    {
            //        _groupButtons[i].ForceActive = false;
            //        //_groupButtons[i].Interactable = false;
            //        continue;
            //    }

            //    if (Selected == i)
            //    {
            //        //_groupButtons[i].Interactable  = true;
            //        _groupButtons[i].ForceActive = true;
            //        continue;
            //    }

            //    //_groupButtons[i].Interactable  = true;
            //    _groupButtons[i].ForceActive = false;
            //}
        }

        protected override void HandleFrequentRender()
        {
            throw new NotImplementedException();
        }
    }
}
