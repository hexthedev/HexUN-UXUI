using HexUN.MonoB;
using System.Collections.Generic;
using UnityEngine;
using HexUN.Events;

#if UNITY_EDITOR
using UnityEditor.Experimental.SceneManagement;
using HexUN.Debugging;
#endif

namespace HexUN.UXUI
{
    /// <summary>
    /// Abstract class for all controls
    /// </summary>
    public abstract class APuiControl : MonoEnhanced
    {
        [Header("Interaction (Control)")]
        [SerializeField]
        [Tooltip("Is this UI eleent interactable")]
        private bool _isInteractable = true;

        [SerializeField]
        [Tooltip("Called when the control interaction state is changed")]
        private BooleanReliableEvent _onInteractationState = new BooleanReliableEvent();

        [SerializeField]
        [Tooltip("References the provider monos")]
        private MonoBehaviour[] _providers = null;

        #region Protected API
        [Header("Proto UI Data (Control)")]
        [SerializeField]
        [Tooltip("Generic data used for querying info about UI control")]
        protected List<ScriptableObject> _puiSoData;

        /// <summary>
        /// All pui data. Pui data can be any type. The puiSoData is only used to allow
        /// adding pui data in editor.
        /// </summary>
        protected List<object> _puiData;
        
        /// <summary>
        /// set to true in order to cause handle render to be called this frame
        /// </summary>
        protected bool RenderThisFrame { get; set; }

        protected override void MonoAwake()
        {
            base.MonoAwake();

            _puiData = new List<object>();
            if (_puiSoData != null) _puiData.AddRange(_puiSoData);
        }
        
        protected virtual void OnValidate()
        {
            ResolveInteractability();
#if UNITY_EDITOR
            PrefabStage s = PrefabStageUtility.GetCurrentPrefabStage();
            UTDevModeManagment.SetDevMode(s != null, transform, _providers);
#endif
        }

        /// <summary>
        /// Handle the logic required when a render occurs
        /// </summary>
        protected abstract void HandleFrameRender();
        #endregion

        #region API
        /// <summary>
        /// The Rect transform of the element
        /// </summary>
        public RectTransform RectTransform => transform as RectTransform;

        /// <summary>
        /// Generic data used for querying info about UI control
        /// </summary>
        public object[] PuiData => _puiSoData.ToArray();

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

        /// <summary>
        /// Initalization code for the ui element
        /// </summary>
        public virtual void Initialize()
        {
            Render();
        }

        /// <summary>
        /// Call to force a render to happen this frame. A render will do work to
        /// update a views visuals. 
        /// </summary>
        public void Render()
        {
            RenderThisFrame = true;
        }

        /// <summary>
        /// Try get the first listed data of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool TryGetData<T>(out T data) where T : ScriptableObject
        {
            foreach(ScriptableObject obj in _puiData)
            {
                T cast = obj as T;

                if (cast != null)
                {
                    data = cast;
                    return true;
                }
            }

            data = default;
            return false;
        }

        /// <summary>
        /// Try get all occurences of a data type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public void TryGetAllData<T>(out List<T> data) where T : ScriptableObject
        {
            data = new List<T>();

            foreach (ScriptableObject obj in _puiData)
            {
                T cast = obj as T;

                if (cast != null)
                {
                    data.Add(cast);
                }
            }
        }

        /// <summary>
        /// Add a pui data to the data
        /// </summary>
        /// <param name="data"></param>
        public void AddPuiData(ScriptableObject data) => _puiData.Add(data);

        /// <summary>
        /// Remove a pui data from data
        /// </summary>
        /// <param name="data"></param>
        public void RemovePuiData(ScriptableObject data) => _puiData.Remove(data);

        /// <summary>
        /// Clear the pui data cache
        /// </summary>
        public void ClearPuiData() => _puiData.Clear();
        #endregion

        private void LateUpdate()
        {
            if (RenderThisFrame)
            {
                HandleFrameRender();
                RenderThisFrame = false;
            }
        }

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