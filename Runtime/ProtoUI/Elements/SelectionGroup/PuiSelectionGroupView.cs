using System;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// The view for a selection group.
    /// </summary>
    public class PuiSelectionGroupView : APuiView<PuiSelectionGroupControl>
    {
        [Header("Options")]
        [SerializeField]
        [Tooltip("The buttons in the group")]
        private PuiButtonControl[] _groupButtons;

        private void Start()
        {
            for(int i = 0; i<_groupButtons.Length; i++)
            {
                _groupButtons[i].OnClick.Subscribe(ClickResponseFactory(i));
            }

            Action ClickResponseFactory(int index) => () =>  Control.RequestSelectionChange(index);
        }

        protected override void HandleFrameRender()
        {
            for (int i = 0; i < _groupButtons.Length; i++)
            {
                // disable
                if (i > Control.MaxActiveIndex)
                {
                    _groupButtons[i].ForceActive = false;
                    _groupButtons[i].SetInteractable(false);
                    continue;
                }

                if (Control.Selected == i)
                {
                    _groupButtons[i].SetInteractable(true);
                    _groupButtons[i].ForceActive = true;
                    continue;
                }

                _groupButtons[i].SetInteractable(true);
                _groupButtons[i].ForceActive = false;
            }
        }
    }
}
