using HexUN.MonoB;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Abstract class for all views
    /// </summary>
    public abstract class APuiControl<T> : APuiControl
        where T: APuiView
    {
        [Header("View")]
        [SerializeField]
        [Tooltip("Control used by the view")]
        protected T View = default;

        #region API
        /// <summary>
        /// Initalization code for the ui element
        /// </summary>
        public override void Initialize()
        {
            View.Initialize();
        }
        #endregion

        protected virtual void OnValidate()
        {
            if (View == null) View = gameObject.GetComponent<T>();
        }
    }

    /// <summary>
    /// Abstract class for all views
    /// </summary>
    public abstract class APuiControl : MonoEnhanced
    {
        [Header("Proto UI Data")]
        [SerializeField]
        [Tooltip("Generic data used for querying info about UI control")]
        protected List<ScriptableObject> _puiData;

        #region API
        /// <summary>
        /// Generic data used for querying info about UI control
        /// </summary>
        public ScriptableObject[] PuiData => _puiData.ToArray();
        
        /// <summary>
        /// Initalization code for the ui element
        /// </summary>
        public virtual void Initialize() { }

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
    }
}