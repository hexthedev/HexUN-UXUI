using System.Collections.Generic;
using UnityEngine;
using HexUN.Events;
using HexUN.Facade;


namespace HexUN.UXUI
{
    /// <summary>
    /// Abstract class for all controls
    /// </summary>
    public abstract class APuiInteractable : APuiControl
    {
        [Header("Interaction (APuiInteractable)")]
        [SerializeField]
        [Tooltip("Is this UI eleent interactable")]
        private bool _isInteractable = true;

        [SerializeField]
        [Tooltip("Called when the control interaction state is changed")]
        private BooleanReliableEvent _onInteractationState = new BooleanReliableEvent();

        [SerializeField]
        [Tooltip("Provides providing interactability")]
        private MonoBehaviour[] _providers = null;

        #region API
        /// <summary>
        /// Is this vontrol interactable
        /// </summary>
        public bool Interactable
        {
            get => _isInteractable;
            set
            {
                if (_isInteractable == value) return;
                _isInteractable = value;
                Render();
                ResolveInteractability();
            }
        }
        #endregion

        #region Protected API
        protected override void OnValidate()
        {
            base.OnValidate();
            ResolveInteractability();
        }
        #endregion

        private void ResolveInteractability()
        {
            if (_providers != null)
            {
                foreach(MonoBehaviour mb in _providers) mb.enabled = _isInteractable;
            }

            _onInteractationState.Invoke(_isInteractable);
        }
    }
}