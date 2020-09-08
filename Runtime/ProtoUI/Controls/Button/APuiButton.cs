using UnityEngine;
using HexCS.Core;
using HexUN.Events;

namespace HexUN.UXUI
{
    public abstract class APuiButton : APuiControl
    {
        [Header("Actions (Button)")]
        [SerializeField]
        protected VoidReliableEvent _onClick = new VoidReliableEvent();

#if HEXDB
        [Header("Debug (AButtonUIControl)")]
        [SerializeField]
#endif
        protected bool _forceActive = false;

#region API
        /// <summary>
        /// Is this button forced active? Meaning it will no longer respond to click events
        /// and will show as active in the view. 
        /// </summary>
        public bool ForceActive
        {
            get => _forceActive;
            set
            {
                if (_forceActive != value) _forceActive = value;
                Render();
            }
        }
        /// <inheritdoc />
        public IEventSubscriber OnClick => _onClick;

        public virtual void Click()
        {
            if (ForceActive) return;
            _onClick.Invoke();
        }
#endregion
    }
}