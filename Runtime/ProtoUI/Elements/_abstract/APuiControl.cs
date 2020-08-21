using HexUN.MonoB;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Abstract class for all controls
    /// </summary>
    public abstract class APuiControl : MonoEnhanced
    {
        [Header("Proto UI Data")]
        [SerializeField]
        [Tooltip("Generic data used for querying info about UI control")]
        protected List<ScriptableObject> _puiData;

        #region Protected API
        /// <summary>
        /// set to true in order to cause handle render to be called this frame
        /// </summary>
        protected bool RenderThisFrame { get; set; }

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
        public ScriptableObject[] PuiData => _puiData.ToArray();

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
    }
}